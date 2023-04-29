using System.Collections.Generic;
using System.Threading.Tasks;
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
        this.db = new PackageRegistryDB();
    }

    [Test]
    public async Task Test1()
    {
        var item = new Dictionary<string, string> {
            {"name", "'bazim'"},
            {"version_major", "1"},
            {"version_minor", "2"},
            {"version_patch", "3"},
            {"content", "''"},
            {"url", "'https://github.com/pytorch/pytorch'"},
            {"js_program", "''"},
        };

        int id = await this.db.packageTable.Insert(item);

        Assert.AreEqual(id, 1);
    }
}