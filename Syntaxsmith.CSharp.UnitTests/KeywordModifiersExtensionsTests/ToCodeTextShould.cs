using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp.UnitTests.KeywordModifiersExtensionsTests;

[TestClass]
public class ToCodeTextShould
{
    [TestMethod]
    public void ReturnEmptyStringWhenNoModifiers()
    {
        KeywordModifiers modifiers = 0;

        var result = modifiers.ToCodeText();

        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void ReturnInOrderWhenAllModifiers()
    {
        var modifiers = KeywordModifiers.File
            | KeywordModifiers.Static
            | KeywordModifiers.Extern
            | KeywordModifiers.New
            | KeywordModifiers.Virtual
            | KeywordModifiers.Abstract
            | KeywordModifiers.Sealed
            | KeywordModifiers.Record
            | KeywordModifiers.Override
            | KeywordModifiers.Readonly
            | KeywordModifiers.Unsafe
            | KeywordModifiers.Required
            | KeywordModifiers.Volatile
            | KeywordModifiers.Async
            | KeywordModifiers.Partial;

        var result = modifiers.ToCodeText();
        var expected = "file static extern new virtual abstract sealed record override readonly unsafe required volatile async partial ";
        Assert.AreEqual(expected, result);
    }
}