using System;
using System.Text;
using System.IO;

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
			Console.WriteLine("running");
			new Program();
			return ProgramStatus;
			
        }

        public Program() {

			

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
			Console.WriteLine(LOG_LEVEL);

			LogDebug("hello");
			// var testMetricCalc = new MetricsCalculation.MetricsCalculator("https://github.com/nodejs/node");
			var testMetricCalc = new MetricsCalculation.MetricsCalculator("https://github.com/BazimAzeem/ECE461-Part2");
			
			testMetricCalc.Calculate();

			LogInfo(testMetricCalc.ToString());
            
        }

		~Program() {
			// append to the log file when we destroy this class
			try
			{
				File.AppendAllText(LOG_FILE, log.ToString());
			}
			catch (DirectoryNotFoundException)
			{
				LogWarning("Log file directory not found. Check your LOG_FILE environment variable");
			}
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
    }
}