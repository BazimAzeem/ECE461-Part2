using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageRegistry
{
    public struct Version
    {
        public int Major, Minor, Patch;
        public Version(int Major, int Minor, int Patch)
        {
            this.Major = Major; this.Minor = Minor; this.Patch = Patch;
        }

        public Version(string version)
        {
            string[] vArray = version.Split(".");
            this.Major = Int32.Parse(vArray[0]);
            this.Minor = Int32.Parse(vArray[1]);
            this.Patch = Int32.Parse(vArray[2]);
        }

        public override string ToString()
        {
            return this.Major.ToString() + "." + this.Minor.ToString() + "." + this.Patch.ToString();
        }
    }

    public class ThePackage
    {
        List<DependancySpec> Dependancies;

        public ThePackage()
        {
            RetrieveDependancies();
        }

        void RetrieveDependancies()
        {
            Dependancies = new List<DependancySpec>();

            // TODO somehow build Dependancies

        }


    }

    public class FilePackage : ThePackage
    {
        string filepath;

        public FilePackage(string filepath)
        {
            this.filepath = filepath;
        }

    }

    public class NPMPackage : ThePackage
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