using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using PackageRegistry;

namespace PackageRegistry.Tests;

[TestFixture]
public class PostgreSQLTests
{
    private PackageRegistryDB db;
    private int id1 = 0;
    private int id2 = 0;

    [SetUp]
    public void Setup()
    {
        this.db = new PackageRegistryDB(local: true);
    }

    [Test, Order(1)]
    public async Task Reset1()
    {
        await this.db.packageTable.Delete();
        try
        {
        }
        catch (System.Exception)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }

    [Test, Order(2)]
    public async Task Insert1()
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

        id1 = await this.db.packageTable.Insert(item);

        Assert.NotNull(id1, "id: {0}", id1);
    }

    [Test, Order(3)]
    public async Task InsertDuplicate()
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

        try
        {
            id1 = await this.db.packageTable.Insert(item);
        }
        catch (Npgsql.PostgresException e)
        {
            if (e.SqlState == Npgsql.PostgresErrorCodes.UniqueViolation)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        catch (System.Exception)
        {
            Assert.Fail();
        }
    }

    [Test, Order(4)]
    public async Task Insert2()
    {
        var item = new Dictionary<string, string> {
            {"name", "'azeem'"},
            {"version_major", "4"},
            {"version_minor", "5"},
            {"version_patch", "6"},
            {"content", "''"},
            {"url", "'https://github.com/lodash/lodash'"},
            {"js_program", "''"},
        };

        id2 = await this.db.packageTable.Insert(item);

        Assert.NotNull(id1, "id: {0}", id2);
    }


    [Test, Order(5)]
    public async Task Select()
    {
        var columns = new List<string> { "id", "name" };
        var where = new Dictionary<string, string> { { "id", id1.ToString() } };
        var rows = new List<Dictionary<string, object>> { };
        try
        {
            rows = await this.db.packageTable.Select(columns, where);
        }
        catch (System.Exception e)
        {
            Assert.Fail();
        }
        Assert.AreEqual("bazim", rows[0]["name"]);
    }

    [Test, Order(6)]
    public async Task Delete()
    {
        var where = new Dictionary<string, string> { { "id", id1.ToString() } };
        try
        {
            await this.db.packageTable.Delete(where);
        }
        catch (System.Exception)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }

    [Test, Order(7)]
    public async Task DeleteNotExist()
    {
        var where = new Dictionary<string, string> { { "id", id1.ToString() } };
        await this.db.packageTable.Delete(where);
        // try
        // {
        // }
        // catch (System.Exception)
        // {
        //     Assert.Fail();
        // }
        // Assert.Pass();
    }

}