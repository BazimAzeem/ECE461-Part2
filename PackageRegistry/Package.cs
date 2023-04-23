using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageRegistry
{
    public struct Version
    {
        int major, minor, patch;
        public Version(int major, int minor, int patch)
        {
            this.major = major; this.minor = minor; this.patch = patch;
        }
    }

    public class Package
    {
        List<DependancySpec> Dependancies;

        public Package()
        {
            RetrieveDependancies();
        }

        void RetrieveDependancies()
        {
            Dependancies = new List<DependancySpec>();

            // TODO somehow build Dependancies

        }


    }

    public class FilePackage : Package
    {
        string filepath;

        public FilePackage(string filepath)
        {
            this.filepath = filepath;
        }

    }

    public class NPMPackage : Package
    {
        string url;
        CLI_Translator metrics_calculator;



        public NPMPackage(string url)
        {
            this.url = url;
            metrics_calculator = new CLI_Translator(url, this);

            metrics_calculator.CalculateMetrics();

        }


    }
}