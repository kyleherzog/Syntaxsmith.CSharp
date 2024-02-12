using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.FieldConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould
{
    [TestMethod]
    public void AppendCorrectlyGivenConstructorOnly()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();

        builder.AppendToContext(context);

        Assert.AreEqual("private MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenCreate()
    {
        var builder = FieldConfigurationBuilder.Create<Int64>("myFieldName");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("private Int64 myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInitializeStringTo()
    {
        var builder = new FieldConfigurationBuilder("string", "myFieldName");
        var context = new SyntaxContext();
        builder.InitializeStringTo("Hello, World!")
            .AppendToContext(context);
        Assert.AreEqual("private string myFieldName = \"Hello, World!\";", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInitializeTo()
    {
        var builder = new FieldConfigurationBuilder("Int32", "myFieldName");
        var context = new SyntaxContext();
        builder.InitializeTo("133")
            .AppendToContext(context);
        Assert.AreEqual("private Int32 myFieldName = 133;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInitializeToWithSemicolon()
    {
        var builder = new FieldConfigurationBuilder("Int32", "myFieldName");
        var context = new SyntaxContext();
        builder.InitializeTo("133;")
            .AppendToContext(context);
        Assert.AreEqual("private Int32 myFieldName = 133;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInternal()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Internal()
            .AppendToContext(context);
        Assert.AreEqual("internal MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenProtected()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Protected()
            .AppendToContext(context);
        Assert.AreEqual("protected MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenProtectedInternal()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.ProtectedInternal()
            .AppendToContext(context);
        Assert.AreEqual("protected internal MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenReadonly()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Readonly()
            .AppendToContext(context);
        Assert.AreEqual("private readonly MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenStatic()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Static()
            .AppendToContext(context);
        Assert.AreEqual("private static MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenUnsafe()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Unsafe()
            .AppendToContext(context);
        Assert.AreEqual("private unsafe MyClass myFieldName;", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenVolatile()
    {
        var builder = new FieldConfigurationBuilder("MyClass", "myFieldName");
        var context = new SyntaxContext();
        builder.Volatile()
            .AppendToContext(context);
        Assert.AreEqual("private volatile MyClass myFieldName;", context.ToString());
    }

    [TestInitialize]
    public void TestInitialize()
    {
        GlobalConfiguration.Reset();
    }
}