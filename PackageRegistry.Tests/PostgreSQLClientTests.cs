using NUnit.Framework;
using PackageRegistry;

namespace PackageRegistry.Tests;

[TestFixture]
public class PostgreSQLClientTests
{
    private PostgreSQLClient postgresClient;

    [SetUp]
    public void Setup()
    {
        postgresClient = new PostgreSQLClient();
    }

    [Test]
    public void Test1()
    {
        postgresClient.SelectAllPackages();
        Assert.Pass();
    }
}