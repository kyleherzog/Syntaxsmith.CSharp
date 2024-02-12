using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.PropertyConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public void AppendCorrectlyGivenAbstract()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Abstract()
            .AppendToContext(context);
        Assert.AreEqual("abstract string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenConstructorOnly()
    {
        var builder = new PropertyConfigurationBuilder("MyClass", "MyPropertyName");
        var context = new SyntaxContext();

        builder.AppendToContext(context);

        Assert.AreEqual("MyClass MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenCreate()
    {
        var builder = PropertyConfigurationBuilder.Create<Int64>("MyPropertyName");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("Int64 MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGetter()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Getter(b => b.AddLine("return \"Hello, World!\";"))
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGetterAndSetter()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Getter(b => b.AddLine("return myPropertyName;"))
            .Setter(b => b.AddLine("myPropertyName = value;"))
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGetterAndSetterWithVisibility()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Public()
            .Getter(b => b.AddLine("return myPropertyName;"))
            .Setter(b => b.AddLine("myPropertyName = value;"))
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInitializer()
    {
        var builder = new PropertyConfigurationBuilder("Int32", "MyPropertyName");
        var context = new SyntaxContext();
        builder.InitializeTo("14")
            .AppendToContext(context);
        Assert.AreEqual("Int32 MyPropertyName { get; set; } = 14;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInitializerWithSemicolon()
    {
        var builder = new PropertyConfigurationBuilder("Int32", "MyPropertyName");
        var context = new SyntaxContext();
        builder.InitializeTo("14;")
            .AppendToContext(context);
        Assert.AreEqual("Int32 MyPropertyName { get; set; } = 14;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInitializeStringTo()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.InitializeStringTo("Hello, World!")
            .AppendToContext(context);
        Assert.AreEqual("string MyPropertyName { get; set; } = \"Hello, World!\";", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInternal()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Internal()
            .AppendToContext(context);
        Assert.AreEqual("internal string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOverride()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Override()
            .AppendToContext(context);
        Assert.AreEqual("override string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPrivate()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Private()
            .AppendToContext(context);
        Assert.AreEqual("private string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenProtected()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Protected()
            .AppendToContext(context);
        Assert.AreEqual("protected string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenProtectedInternal()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.ProtectedInternal()
            .AppendToContext(context);
        Assert.AreEqual("protected internal string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public string MyPropertyName { get; set; }", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenReadOnly()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.ReadOnly()
            .AppendToContext(context);
        Assert.AreEqual("string MyPropertyName { get; }", context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenSetter()
    {
        var builder = new PropertyConfigurationBuilder("string", "MyPropertyName");
        var context = new SyntaxContext();
        builder.Setter(b => b.AddLine("myPropertyName = value;"))
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestInitialize]
    public void TestInitialize()
    {
        GlobalConfiguration.Reset();
    }
}