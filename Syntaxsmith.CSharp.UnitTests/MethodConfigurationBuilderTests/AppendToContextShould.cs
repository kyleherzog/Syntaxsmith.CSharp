using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.MethodConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public void AppendCorrectlyGivenAbstract()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Abstract()
            .AppendToContext(context);
        Assert.AreEqual("abstract void Test();", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenComplexAbstractConfiguration()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
                .Public()
                .Abstract()
                .Partial()
                .AppendToContext(context);
        Assert.AreEqual("public abstract partial void Test<T>();", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenComplexStaticConfiguration()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
                .Public()
                .Static()
                .AppendToContext(context);
        Assert.AreEqual("public static void Test<T>()", context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithConstraint()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraints()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "IInterface")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInternal()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Internal()
            .AppendToContext(context);
        Assert.AreEqual("internal void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenMultipleGenericParameters()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
            .WithGenericParameter("U")
            .AppendToContext(context);
        Assert.AreEqual("void Test<T, U>()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPartial()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Partial()
            .AppendToContext(context);
        Assert.AreEqual("partial void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPrivate()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Private()
            .AppendToContext(context);
        Assert.AreEqual("private void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenProtected()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Protected()
            .AppendToContext(context);
        Assert.AreEqual("protected void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenProtectedInternal()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.ProtectedInternal()
            .AppendToContext(context);
        Assert.AreEqual("protected internal void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenReturningByString()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Returning("int")
            .AppendToContext(context);
        Assert.AreEqual("int Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenReturningByType()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Returning<Int32>()
            .AppendToContext(context);
        Assert.AreEqual("Int32 Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenReturningGenericType()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Returning<List<Int32>>()
            .AppendToContext(context);
        Assert.AreEqual("List<Int32> Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenSealed()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Sealed()
            .AppendToContext(context);
        Assert.AreEqual("sealed void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenStatic()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Static()
            .AppendToContext(context);
        Assert.AreEqual("static void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenVoid()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("void Test()", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenWithGenericParameter()
    {
        var builder = new MethodConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
            .AppendToContext(context);
        Assert.AreEqual("void Test<T>()", context.ToString());
    }
}