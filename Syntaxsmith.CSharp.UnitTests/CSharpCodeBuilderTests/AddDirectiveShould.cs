namespace Syntaxsmith.CSharp.UnitTests.CSharpCodeBuilderTests;

[TestClass]
public class AddDirectiveShould : VerifyBase
{
    [TestMethod]
    public void AddGivenNoTextSpecified()
    {
        var builder = new CSharpCodeBuilder();
        var result = builder.AddDirective(PreprocessorDirective.NullableEnable)
            .Build();
        var expected = "#nullable enable";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void AddGivenTextSpecified()
    {
        var builder = new CSharpCodeBuilder();
        var result = builder.AddDirective(PreprocessorDirective.If, "NET8_0")
            .Build();
        var expected = "#if NET8_0";
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public Task AddWithoutIndentingGivenOpenBlock()
    {
        var builder = new CSharpCodeBuilder();
        var result = builder.BlockOpen()
            .BlockOpen()
            .AddDirective(PreprocessorDirective.If, "true")
            .BlockClose()
            .BlockClose()
            .Build();
        return Verify(result);
    }
}