using Syntaxsmith.CSharp.Configuration;
using Syntaxsmith.CSharp.UnitTests.Models;

namespace Syntaxsmith.CSharp.UnitTests.InterfaceConfigurationBuilderTests;

[TestClass]
public class AppendToContextShould : VerifyBase
{
    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithConstraint()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraints()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "new()")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public Task AppendCorrectlyGivenGenericParameterWithMultipleConstraintsAndMultipleParameters()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T", "class", "new()")
            .WithGenericParameter("U", "struct")
            .AppendToContext(context);
        return Verify(context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByString()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Inherits("ITestBase")
            .AppendToContext(context);
        Assert.AreEqual("interface ITest : ITestBase", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenMultipleInheritsByString()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Inherits("ITestBase", "IDisposable")
            .AppendToContext(context);
        Assert.AreEqual("interface ITest : ITestBase, IDisposable", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByGeneric()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Inherits<ITestPerson>()
            .AppendToContext(context);
        Assert.AreEqual("interface ITest : ITestPerson", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenInheritsByType()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Inherits(typeof(ITestPerson))
            .AppendToContext(context);
        Assert.AreEqual("interface ITest : ITestPerson", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenMultipleInheritsByType()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Inherits(typeof(ITestPerson), typeof(IDisposable))
            .AppendToContext(context);
        Assert.AreEqual("interface ITest : ITestPerson, IDisposable", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOneGenericParameter()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T");
        builder.AppendToContext(context);
        Assert.AreEqual("interface ITest<T>", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenOnlyName()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.AppendToContext(context);
        Assert.AreEqual("interface ITest", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPartial()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Partial()
            .AppendToContext(context);
        Assert.AreEqual("partial interface ITest", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenPublic()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.Public()
            .AppendToContext(context);
        Assert.AreEqual("public interface ITest", context.ToString());
    }

    [TestMethod]
    public void AppendCorrectlyGivenTwoGenericParameters()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        var context = new SyntaxContext();
        builder.WithGenericParameter("T")
            .WithGenericParameter("U")
            .AppendToContext(context);
        Assert.AreEqual("interface ITest<T, U>", context.ToString());
    }

    [TestMethod]
    public void ThrowArgumentNullExceptionGivenContextIsNull()
    {
        var builder = new InterfaceConfigurationBuilder("ITest");
        Assert.ThrowsException<ArgumentNullException>(() => builder.AppendToContext(null!));
    }
}