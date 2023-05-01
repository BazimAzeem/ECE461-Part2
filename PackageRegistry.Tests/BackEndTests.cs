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

    [Test, Order(1)]
    public async Task Reset1()
    {
        try
        {
            await this.db.packageTable.Delete();
        }
        catch (System.Exception)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }

    [Test, Order(2)]
    public async Task Insert()
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

        Assert.NotNull(id);
    }
}