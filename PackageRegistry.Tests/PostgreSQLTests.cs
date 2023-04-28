using NUnit.Framework;
using PackageRegistry;

namespace PackageRegistry.Tests;

[TestFixture]
public class PostgreSQLTests
{
    private PackageRegistryDB db;

    [SetUp]
    public void Setup()
    {
        db = new PackageRegistryDB();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}