using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageRegistry
{
    public class CLI_Translator
    {
        string packageUrl;
        Package parentPackage;
        MetricsCalculation.MetricsCalculator metricsCalculator;

        public CLI_Translator(string url, Package parent)
        {
            this.packageUrl = url;
            this.parentPackage = parent;

            metricsCalculator = new MetricsCalculation.MetricsCalculator(url);
        }

        public void CalculateMetrics()
        {

            metricsCalculator.Calculate();
        }
    }
}