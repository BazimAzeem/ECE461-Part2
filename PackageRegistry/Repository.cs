using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageRegistry
{
    public struct Version {
        int major, minor, patch;
        public Version(int major, int minor, int patch) {
            this.major = major; this.minor = minor; this.patch = patch;
        }
    }
    
    public class Repository
    {
        string url;
        CLI_Translator metrics_calculator;

        public Repository(string url) {
            this.url = url;
            metrics_calculator = new CLI_Translator(url, this);
        }
    }
}