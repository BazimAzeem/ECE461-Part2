using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PackageRegistry.MetricsCalculation
{
    public class MetricsCalculator
    {
        
        public string url;
        public string owner, name;

		public float score = -1;

		private List<Metric> metrics = new List<Metric>();
		public List<Task> calcMetricTaskQueue = new List<Task>();

        public MetricsCalculator(string url) {

			url = url.Contains("npmjs") ? GetUrlFromNpmUrl(url) : url;
			this.url = url;

            // get the user name and repository name
			string[] phrases = url.Split("/");
			if (phrases.Length <= 2)
			{
				Program.LogError("Invalid github url: " + url);
				this.owner = "invalid";
				this.name = "invalid";
			}
			else
			{
				this.owner = phrases[phrases.Length - 2];
				this.name = phrases[phrases.Length - 1];
				if (this.name.Contains(".git"))
				{
					this.name = this.name.Substring(0, this.name.Length - 4);
				}
			}

			// add metrics to metric list 
			metrics.Add(new RampUp(this));
			metrics.Add(new Correctness(this));
			metrics.Add(new BusFactor(this));
			metrics.Add(new ResponsiveMaintainer(this));
			metrics.Add(new LicenseMetric(this));
			metrics.Add(new PRRatio(this));

			// start the metrics calculating
			foreach (Metric m in metrics) {
				try {
					calcMetricTaskQueue.Add(m.Calculate());
				}
				catch (Exception e) {
					Program.LogError("An unexpected Exception Occured. Please check your URL_FILE, and the validity of your repos." + e.ToString());
				}
			}
        }

		
		public override string ToString() {
			return ToOutput();
		}

		public string ToOutput()
		{
			
			string jsonBlob = "{ \"URL\":\"" + this.url + "\", \"NET_SCORE\":" + Math.Round(this.score, 2);
			foreach (Metric m in metrics)
			{
				jsonBlob += ", \"" + m.name + "\":" + m.GetScore();
			}
			jsonBlob += "}";

			return jsonBlob;
		}


		public float Calculate() {

			if (this.score != -1) return this.score;

			// wait for tasks calculateTasks to finish
			foreach (Task t in calcMetricTaskQueue) {
				try {
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


		private async static Task<string> scrapeForGitUrl(string url)
		{

			// get package name from url
			string[] phrases = url.Split("/");
			string packageName = phrases[phrases.Length - 1];

			using var client = new HttpClient();

			var result = await client.GetStringAsync("https://registry.npmjs.org/" + packageName);

			// HACK this may be the least robust possible way of doing this 
			string[] tokens = result.Split("\"");
			foreach (string s in tokens)
			{
				if (s.Contains("github.com"))
				{
					return s;
				}
			}

			return "no_url_found";

		}

		public static string GetUrlFromNpmUrl(string url)
		{

			Task<string> urlScrape = scrapeForGitUrl(url);

			try
			{
				urlScrape.Wait(TimeSpan.FromSeconds(Program.REQUEST_TIMEOUT_TIME));
			}
			catch (AggregateException)
			{ // probably a 404 error
				Program.LogError("Invalid library url: " + url);
				return null;
			}
			string gitUrl = urlScrape.Result;

			return gitUrl;
		}


    }
}