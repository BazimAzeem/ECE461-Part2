using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using PackageRegistry.Models;

namespace PackageRegistry.Tests;

[TestFixture]
public class PackageCreateTests
{
    [Test]
    public async Task CreateFromContentFechaSuccess()
    {
        string content = File.ReadAllText("../../../base64/fecha");

        Package expected = new Package();
        expected.Metadata.Name = "fecha";
        expected.Metadata.Version = "4.2.3";
        expected.Data.URL = "https://github.com/taylorhakes/fecha";
        expected.Data.Content = content;

        Package package = null;
        try
        {
            package = await Package.CreateFromContent(content);
        }
        catch (System.Exception)
        {
            Assert.Fail();
        }

        Assert.AreEqual(expected, package);
    }

    [Test]
    public async Task CreateFromContentLodashNoHomepage()
    {
        string content = File.ReadAllText("../../../base64/lodash");

        Package expected = new Package();
        expected.Metadata.Name = "lodash";
        expected.Metadata.Version = "5.0.0";
        expected.Data.URL = "https://github.com/lodash/lodash";
        expected.Data.Content = content;

        Package package = null;
        try
        {
            package = await Package.CreateFromContent(content);
        }
        catch (System.Exception)
        {
            Assert.Pass();
        }
        Assert.Fail();
    }

    [Test]
    public async Task CreateFromURLLodash()
    {
        string url = "https://github.com/lodash/lodash";

        Package expected = new Package();
        expected.Metadata.Name = "lodash";
        expected.Metadata.Version = "5.0.0";
        expected.Data.URL = url;
        expected.Data.Content = File.ReadAllText("../../../base64/lodash");

        Package package = await Package.CreateFromURL(url);
        Assert.AreEqual(expected.Metadata, package.Metadata);
    }
}