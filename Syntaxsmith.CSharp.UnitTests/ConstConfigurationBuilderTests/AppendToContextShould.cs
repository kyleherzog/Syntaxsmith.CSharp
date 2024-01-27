using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.ConstConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould
{
    [TestMethod]
    public void AppendCorrectlyGivenCreate()
    {
        var builder = ConstConfigurationBuilder.Create<Boolean>("MyConst", true);
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("const Boolean MyConst = true;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInternal()
    {
        var builder = new ConstConfigurationBuilder("String", "MyConst", "Value Here");
        var context = new SyntaxContext();
        builder.Internal()
            .AppendToContext(context);
        Assert.AreEqual("internal const String MyConst = \"Value Here\";", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPrivate()
    {
        var builder = new ConstConfigurationBuilder("String", "MyConst", "Value Here");
        var context = new SyntaxContext();
        builder.Private()
            .AppendToContext(context);
        Assert.AreEqual("private const String MyConst = \"Value Here\";", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new ConstConfigurationBuilder("String", "MyConst", "Value Here");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public const String MyConst = \"Value Here\";", context.ToString());
    }

    [TestInitialize]
    public void TestInitialize()
    {
        GlobalConfiguration.Reset();
    }
}