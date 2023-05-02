using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using PackageRegistry.Models;
using PackageRegistry.MetricsCalculation;


[TestFixture]
public class MetricCalculationTests
{
    

    [Test]
    public void TestMetrics()
    {
        string[] urls = new string[] {"https://github.com/lodash/lodash", "https://github.com/taylorhakes/fecha"};

        MetricsCalculator[] metricsCalculators = new MetricsCalculator[urls.Length];

        for (int i = 0; i < urls.Length; i++){
            metricsCalculators[i] = new MetricsCalculator(urls[i]);
            metricsCalculators[i].Calculate();
        }

        
        for (int i = 0; i < urls.Length; i++){
            Console.WriteLine(metricsCalculators[i].ToString());
        }
       
        // Assert.AreEqual(expected.Metadata, package.Metadata);
    }
}