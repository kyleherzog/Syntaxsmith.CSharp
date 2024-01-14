using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.XmlDocsConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public void AppendCorrectlyGivenInherits()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Inherits()
            .AppendToContext(context);
        Assert.AreEqual("/// <inheritdoc/>", context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenExceptionAsGeneric()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddException<InvalidOperationException>("Thrown when the object has not been initialized.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenExceptionAsString()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddException("ArgumentException", "Thrown when there is a bad value.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenExceptionAsType()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddException(typeof(ArgumentOutOfRangeException), "Thrown when the value is too big.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public void AppendsCorrectlyGivenIndented()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        context.IndentLevel++;
        builder.Inherits()
            .AppendToContext(context);
        Assert.AreEqual("    /// <inheritdoc/>", context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenMultipleExceptionsAsString()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddException("ArgumentNullException", "Thrown when there is a null value.")
            .AddException("ArgumentException", "Thrown when there is a bad value.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenMultipleParams()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddParam("name", "The name of the item.")
            .AddParam("description", "The description of the item.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenOneParam()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddParam("value", "The value to be applied.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenReturns()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AddParam("name", "The name of the item.")
            .AddParam("description", "The description of the item.")
            .Returns("The newly created object.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendsCorrectlyGivenSummaryOnly()
    {
        var builder = new XmlDocsConfigurationBuilder();
        var context = new SyntaxContext();
        builder.Summary("This does that.")
            .AppendToContext(context);
        return Verify(context.ToString());
    }
}