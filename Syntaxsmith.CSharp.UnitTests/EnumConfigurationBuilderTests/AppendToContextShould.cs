using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.EnumConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public void AppendCorrectlyGivenGlobalConfig()
    {
        GlobalConfiguration.Enum = o => o.Public();
        var builder = new EnumConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("public enum Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOnlyName()
    {
        var builder = new EnumConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("enum Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new EnumConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public enum Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenUnderlyingByGeneric()
    {
        var builder = new EnumConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.UnderlyingType<Int64>()
            .AppendToContext(context);
        Assert.AreEqual("enum Test : Int64", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenUnderlyingByString()
    {
        var builder = new EnumConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.UnderlyingType("long")
            .AppendToContext(context);
        Assert.AreEqual("enum Test : long", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenUnderlyingByType()
    {
        var builder = new EnumConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.UnderlyingType(typeof(Int64))
            .AppendToContext(context);
        Assert.AreEqual("enum Test : Int64", context.ToString());
    }

    [TestInitialize]
    public void TestInitialize()
    {
        GlobalConfiguration.Reset();
    }

    [TestMethod]
    public void ThrowArgumentNullExceptionGivenContextIsNull()
    {
        var builder = new EnumConfigurationBuilder("Test");
        Assert.ThrowsException<ArgumentNullException>(() => builder.AppendToContext(null!));
    }
}