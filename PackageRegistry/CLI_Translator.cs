using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageRegistry
{
    public class CLI_Translator
    {
        string packageUrl;
        Repository parentRepository;

        public CLI_Translator(string url, Repository parent)
        {
            this.packageUrl = url;
            this.parentRepository = parent;
        }

        public void CalculateMetrics()
        {
            // TODO call bad CLI For the url and metrics of the other project
        }
    }
}