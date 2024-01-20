using Syntaxsmith.CSharp.Configuration;
using Syntaxsmith.CSharp.UnitTests.Models;

namespace Syntaxsmith.CSharp.UnitTests.ClassConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public void AppendCorrectlyGivenAbstract()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Abstract()
            .AppendToContext(context);
        Assert.AreEqual("abstract class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenComplexAbstractConfiguration()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
                .Public()
                .Abstract()
                .Partial()
                .Inherits("BaseClass")
                .Implements("IInterface", "IInterface2")
                .AppendToContext(context);
        Assert.AreEqual("public abstract partial class Test<T> : BaseClass, IInterface, IInterface2", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenComplexStaticConfiguration()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
                .Public()
                .Static()
                .Inherits("BaseClass")
                .Implements("IInterface", "IInterface2")
                .AppendToContext(context);
        Assert.AreEqual("public static class Test<T> : BaseClass, IInterface, IInterface2", context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithConstraint()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraints()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "new()")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraintsAndMultipleParameters()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "new()")
            .WithGenericParameter("U", "struct")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenGlobalConfig()
    {
        GlobalConfiguration.Class = o => o.Public();
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Abstract()
            .AppendToContext(context);
        Assert.AreEqual("public abstract class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsAndInterface()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits("BaseClass")
            .Implements("IInterface")
            .AppendToContext(context);
        Assert.AreEqual("class Test : BaseClass, IInterface", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsAndTwoInterfaces()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits("BaseClass")
            .Implements("IInterface", "IInterface2")
            .AppendToContext(context);
        Assert.AreEqual("class Test : BaseClass, IInterface, IInterface2", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByGeneric()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits<TestPerson>()
            .AppendToContext(context);
        Assert.AreEqual("class Test : TestPerson", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByString()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits("BaseClass")
            .AppendToContext(context);
        Assert.AreEqual("class Test : BaseClass", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByType()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits(typeof(TestPerson))
            .AppendToContext(context);
        Assert.AreEqual("class Test : TestPerson", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOneGenericParameter()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T");
        builder.AppendToContext(context);
        Assert.AreEqual("class Test<T>", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOnlyClassName()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPartial()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Partial()
            .AppendToContext(context);
        Assert.AreEqual("partial class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenSealed()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Sealed()
            .AppendToContext(context);
        Assert.AreEqual("sealed class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenStatic()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Static()
            .AppendToContext(context);
        Assert.AreEqual("static class Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenTwoGenericParameters()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
            .WithGenericParameter("U")
            .AppendToContext(context);
        Assert.AreEqual("class Test<T, U>", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenUnsafe()
    {
        var builder = new ClassConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Unsafe()
            .AppendToContext(context);
        Assert.AreEqual("unsafe class Test", context.ToString());
    }

    [TestInitialize]
    public void TestInitialize()
    {
        GlobalConfiguration.Reset();
    }

    [TestMethod]
    public void ThrowArgumentNullExceptionGivenContextIsNull()
    {
        var builder = new ClassConfigurationBuilder("Test");
        Assert.ThrowsException<ArgumentNullException>(() => builder.AppendToContext(null!));
    }
}