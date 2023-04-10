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

        public CLI_Translator(string url, Package parent)
        {
            this.packageUrl = url;
            this.parentPackage = parent;
        }

        public void CalculateMetrics()
        {
            // TODO call bad CLI For the url and metrics of the other project
        }
    }
}