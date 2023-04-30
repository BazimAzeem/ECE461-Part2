using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Google.Api;
using Google.Api.Gax.Grpc;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.Logging.V2;
using Google.Cloud.Logging.Type;
using Grpc.Core;


namespace PackageRegistry
{
    public class Program
    {
        // parameters
        public const double REQUEST_TIMEOUT_TIME = 10;



        // members
        public static short LOG_LEVEL = 1; // 0 is silent, 1 means informational messages, 2 means debug messages
        public static string LOG_FILE = "./bin/log_file.txt";
        public static short ProgramStatus = 0;
        public static StringBuilder log = new StringBuilder();


        public static int Main(String[] args)
        {
           
            new Program(args);
            return ProgramStatus;

        }

        public Program(String[] args)
        {
            // get the log level from environment variable or our class params
            string log_level_env_var = Environment.GetEnvironmentVariable("LOG_LEVEL");
            if (!(log_level_env_var is null) && log_level_env_var.Length > 0)
            {
                try
                {
                    LOG_LEVEL = short.Parse(log_level_env_var);
                }
                catch (Exception)
                {
                    LogError("invalid value for LOG_LEVEL environment variable: " + log_level_env_var + "   Should be an integer [0,2]");
                }
            }

            string log_file_env_var = Environment.GetEnvironmentVariable("LOG_FILE");
            if (!(log_file_env_var is null) && log_file_env_var.Length > 0)
            {
                LOG_FILE = log_file_env_var;
            }
			
			// Test metric stuff
			var calculator1 = new MetricsCalculation.MetricsCalculator("https://github.com/BazimAzeem/ECE461-Part2");
			var calculator2 = new MetricsCalculation.MetricsCalculator("https://github.com/npm/cli");
			var calculator3 = new MetricsCalculation.MetricsCalculator("https://github.com/microsoft/vscode");
			var calculator4 = new MetricsCalculation.MetricsCalculator("https://github.com/shinout/browser");
			calculator1.Calculate();
			calculator2.Calculate();
			calculator3.Calculate();
			calculator4.Calculate();
			LogInfo(calculator1.ToString());
			LogInfo(calculator2.ToString());
			LogInfo(calculator3.ToString());
			LogInfo(calculator4.ToString());

			// TODO 
			// FIXME Delete this!
			return;

			try {
           		CreateWebHostBuilder(args).Build().Run();
			}catch (Exception ex) {
				string logMessage = string.Format("Exception message: {0}\nException type: {1}\nStack trace:\n{2}",
					ex.Message, ex.GetType().FullName, ex.StackTrace);
				if (ex.InnerException != null)
				{
					logMessage += string.Format("\n\nInner exception message: {0}\nInner exception type: {1}\nInner exception stack trace:\n{2}",
						ex.InnerException.Message, ex.InnerException.GetType().FullName, ex.InnerException.StackTrace);
				}
			
				LogError("Unexcepted exception occured in CreateWebHostBuilder " + logMessage);
			}
        }

        /// <summary>
        /// Create the web host builder.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();


        

		public void AppendToLog() {
            // append to the log file when we destroy this class
            try
            {
                File.AppendAllText(LOG_FILE, log.ToString());
				log.Clear();
			}
            catch (DirectoryNotFoundException)
            {
                LogWarning("Log file directory not found. Check your LOG_FILE environment variable");
            }
		}

		~Program()
        {
			AppendToLog();
        }



        public static void LogError(string msg)
        {
            ProgramStatus = 1; // set that we had an error so we return EXIT_FAILURE

            string outmsg = "[ERROR] " + msg;

            if (LOG_LEVEL >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(outmsg);
                Console.ForegroundColor = ConsoleColor.White;

                log.AppendLine(outmsg);
            }


        }
        public static void LogWarning(string msg)
        {

            string outmsg = "[WARNING] " + msg;

            if (LOG_LEVEL >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(outmsg);
                Console.ForegroundColor = ConsoleColor.White;

                log.AppendLine(outmsg);
            }
        }

        public static void LogInfo(string msg)
        {
            string outmsg = "[INFO] " + msg;

            if (LOG_LEVEL >= 1)
            {
                Console.WriteLine(outmsg);

                log.AppendLine(outmsg);
            }
        }

        public static void LogDebug(string msg)
        {
            string outmsg = "[DEBUG] " + msg;

            if (LOG_LEVEL >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(outmsg);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (LOG_LEVEL >= 1)
            {
                log.AppendLine(outmsg);
            }
        }

        private static readonly CallSettings _retryAWhile = CallSettings.FromRetry(
            RetrySettings.FromExponentialBackoff(
                maxAttempts: 15,
                initialBackoff: TimeSpan.FromSeconds(3),
                maxBackoff: TimeSpan.FromSeconds(12),
                backoffMultiplier: 2.0,
                retryFilter: RetrySettings.FilterForStatusCodes(StatusCode.Internal, StatusCode.DeadlineExceeded)));

        public static void WriteLogEntry(string logId, string message)
        {
            var client = LoggingServiceV2Client.Create();
            LogName logName = new LogName("ece-461-380500", logId);
            LogEntry logEntry = new LogEntry
            {
                LogNameAsLogName = logName,
                Severity = LogSeverity.Debug,
                TextPayload = message
            };
            MonitoredResource resource = new MonitoredResource { Type = "global" };
            IDictionary<string, string> entryLabels = new Dictionary<string, string>
                {
                    { "size", "large" },
                    { "color", "red" }
                };
            client.WriteLogEntries(logName, resource, entryLabels,
                new[] { logEntry }, _retryAWhile);
            Console.WriteLine($"Created log entry in log-id: {logId}.");
        }
    }
}