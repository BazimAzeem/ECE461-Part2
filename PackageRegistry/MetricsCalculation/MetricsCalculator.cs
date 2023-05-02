using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using PackageRegistry.Models;

namespace PackageRegistry.MetricsCalculation
{
    public class MetricsCalculator
    {   
        const short ERROR_SUCCESS = 0;
        const short ERROR_WARNING = 1;
        const short ERROR_ERROR = 2;
        public string url;
        public string owner, name;

        public float score = -1;

        public int error_level = ERROR_SUCCESS;
        public string error_message = "";

        private List<Metric> metrics = new List<Metric>();

        public Metric RampUp, Correctness, BusFactor, ResponsiveMaintainer, LicenseScore, PullRequest, GoodPinningPractice;
        public List<Task> calcMetricTaskQueue = new List<Task>();

        public MetricsCalculator(string url)
        {

            this.url = url.Contains("npmjs") ? Package.GetUrlFromNpmUrl(url) : url;
            (this.owner, this.name) = Package.GetOwnerAndNameFromURL(this.url);

            // add metrics to metric list 
            RampUp = new RampUp(this);
            Correctness = new Correctness(this);
            BusFactor = new BusFactor(this);
            ResponsiveMaintainer = new ResponsiveMaintainer(this);
            LicenseScore = new LicenseScore(this);
            PullRequest = new PullRequest(this);
            GoodPinningPractice = new GoodPinningPractice(this);

            metrics.Add(BusFactor);
            metrics.Add(Correctness);
            metrics.Add(RampUp);
            metrics.Add(ResponsiveMaintainer);
            metrics.Add(LicenseScore);
            metrics.Add(GoodPinningPractice);
            metrics.Add(PullRequest);


            // start the metrics calculating
            foreach (Metric m in metrics)
            {
                try
                {
                    calcMetricTaskQueue.Add(m.Calculate());
                }
                catch (Exception e)
                {
                    Program.LogError("An unexpected Exception Occured. Please check your URL_FILE, and the validity of your repos." + e.ToString());
                }
            }
        }


        public override string ToString()
        {
            return ToOutput();
        }

        public string ToOutput()
        {

            string jsonBlob = "{ \"URL\":\"" + this.url + "\", \"netScore\":" + Math.Round(this.score, 2);
            foreach (Metric m in metrics)
            {
                jsonBlob += ", \"" + m.name + "\":" + m.GetScore();
            }
            jsonBlob += "}";

            return jsonBlob;
        }


        public float Calculate()
        {

            if (this.score != -1) return this.score;

            // wait for tasks calculateTasks to finish
            foreach (Task t in calcMetricTaskQueue)
            {
                try
                {
                    t.Wait(TimeSpan.FromSeconds(Program.REQUEST_TIMEOUT_TIME));

                }
                catch (Exception e)
                {
                    Program.LogError("An unexpected Exception Occured. Please check your URL_FILE, and the validity of your repos." + e.ToString());

                }
            }

            // calculate a weighted average of all the scores of the other metrics
            float runningSum = 0;
            float divisor = 0;
            foreach (Metric m in metrics)
            {
                runningSum += m.score == -1 ? 0 : m.weight * m.score;
                divisor += m.weight;
            }

            if (divisor == 0) divisor = 1; // avoid a divide by zero (most likely because this lib has no metrics other than netscore)

            this.score = runningSum / divisor;

            return this.score;
        }
        

        public void LogDebug(string message) {
            Program.LogDebug(message);
        }
        public void LogInfo(string message) {
            Program.LogInfo(message);
        }
        public void LogError(string message) {
            if (error_level <= ERROR_ERROR) {
                error_message = message;
                error_level = ERROR_ERROR;
            }
            Program.LogError(message);
        }

        public void LogWarning(string message) {
            if (error_level <= ERROR_WARNING) {
                error_message = message;
                error_level = ERROR_WARNING;
            }
            Program.LogWarning(message);
        }
    }
    
}