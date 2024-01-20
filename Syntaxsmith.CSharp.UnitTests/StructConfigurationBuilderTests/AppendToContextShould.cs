using Syntaxsmith.CSharp.Configuration;
using Syntaxsmith.CSharp.UnitTests.Models;

namespace Syntaxsmith.CSharp.UnitTests.StructConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public void AppendCorrectlyGivenAbstract()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Abstract()
            .AppendToContext(context);
        Assert.AreEqual("abstract struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenComplexAbstractConfiguration()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
                .Public()
                .Abstract()
                .Partial()
                .Inherits("BaseObject")
                .Implements("IInterface", "IInterface2")
                .AppendToContext(context);
        Assert.AreEqual("public abstract partial struct Test<T> : BaseObject, IInterface, IInterface2", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenComplexStaticConfiguration()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
                .Public()
                .Static()
                .Inherits("BaseObject")
                .Implements("IInterface", "IInterface2")
                .AppendToContext(context);
        Assert.AreEqual("public static struct Test<T> : BaseObject, IInterface, IInterface2", context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithConstraint()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraints()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "new()")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraintsAndMultipleParameters()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "new()")
            .WithGenericParameter("U", "struct")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenGlobalConfiguration()
    {
        GlobalConfiguration.Struct = o => o.Public();
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("public struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsAndInterface()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits("BaseObject")
            .Implements("IInterface")
            .AppendToContext(context);
        Assert.AreEqual("struct Test : BaseObject, IInterface", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsAndTwoInterfaces()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits("BaseObject")
            .Implements("IInterface", "IInterface2")
            .AppendToContext(context);
        Assert.AreEqual("struct Test : BaseObject, IInterface, IInterface2", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByGeneric()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits<TestPerson>()
            .AppendToContext(context);
        Assert.AreEqual("struct Test : TestPerson", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByString()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits("BaseObject")
            .AppendToContext(context);
        Assert.AreEqual("struct Test : BaseObject", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByType()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Inherits(typeof(TestPerson))
            .AppendToContext(context);
        Assert.AreEqual("struct Test : TestPerson", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOneGenericParameter()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T");
        builder.AppendToContext(context);
        Assert.AreEqual("struct Test<T>", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOnlyName()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPartial()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Partial()
            .AppendToContext(context);
        Assert.AreEqual("partial struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenSealed()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Sealed()
            .AppendToContext(context);
        Assert.AreEqual("sealed struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenStatic()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Static()
            .AppendToContext(context);
        Assert.AreEqual("static struct Test", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenTwoGenericParameters()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
            .WithGenericParameter("U")
            .AppendToContext(context);
        Assert.AreEqual("struct Test<T, U>", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenUnsafe()
    {
        var builder = new StructConfigurationBuilder("Test");
        var context = new SyntaxContext();
        builder.Unsafe()
            .AppendToContext(context);
        Assert.AreEqual("unsafe struct Test", context.ToString());
    }

    [TestInitialize]
    public void TestInitialize()
    {
        GlobalConfiguration.Reset();
    }

    [TestMethod]
    public void ThrowArgumentNullExceptionGivenContextIsNull()
    {
        var builder = new StructConfigurationBuilder("Test");
        Assert.ThrowsException<ArgumentNullException>(() => builder.AppendToContext(null!));
    }
}