using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp.UnitTests.ClassConfigurationBuilderTests;

[TestClass]
public class ConstructorShould
{
    [DataTestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow("1")]
    [DataRow("1Test")]
    [DataRow("Test-This")]
    [DataRow("*")]
    public void ThrowArgumentExceptionGivenClassNameIsInvalid(string className)
    {
        Assert.ThrowsException<ArgumentException>(() => new ClassConfigurationBuilder(className));
    }

    [TestMethod]
    public void ThrowArgumentNullExceptionGivenClassNameIsNull()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new ClassConfigurationBuilder(null!));
    }
}