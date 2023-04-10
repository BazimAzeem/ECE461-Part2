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

    public class Repository
    {
        List<DependancySpec> Dependancies;

        public Repository()
        {
            RetrieveDependancies();
        }

        void RetrieveDependancies()
        {
            Dependancies = new List<DependancySpec>();

            // TODO somehow build Dependancies

        }


    }

    public class FileRepository : Repository
    {
        string filepath;

        public FileRepository(string filepath)
        {
            this.filepath = filepath;
        }

    }

    public class NPMRepository : Repository
    {
        string url;
        CLI_Translator metrics_calculator;



        public NPMRepository(string url)
        {
            this.url = url;
            metrics_calculator = new CLI_Translator(url, this);

            metrics_calculator.CalculateMetrics();

        }


    }
}