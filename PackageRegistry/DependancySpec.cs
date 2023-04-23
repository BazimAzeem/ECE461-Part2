using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageRegistry
{
    public class DependancySpec
    {

        public string name;
        public Version oldBound; // the oldest version we may use
        public Version latestBound; // the newest version we may use
        public Package selectedPackage; // the version we currently have selected

        public bool versionSelected = false, traversed = false;

        public DependancySpec(string name, Version oldBound, Version latestBound)
        {
            this.name = name; this.oldBound = oldBound; this.latestBound = latestBound;
        }

        public Package SelectVersion()
        {
            return null;
        }
    }
}