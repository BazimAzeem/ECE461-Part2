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
    
    public class DependancySpec {
        public Version lowerBound = null;
        public Version uppperBound = null;
        public Repository selectedRepo = null;
    }

    public class Repository
    {
        string url;
        CLI_Translator metrics_calculator;

        List<DependancySpec> Dependancies;

        public Repository(string url) {
            this.url = url;
            metrics_calculator = new CLI_Translator(url, this);

            metrics_calculator.CalculateMetrics();

            RetrieveDependancies();
        }

        RetrieveDependancies() {
            Dependancies = new List<Repository>();
            
            // TODO somehow build Dependancies

        }
    }
}