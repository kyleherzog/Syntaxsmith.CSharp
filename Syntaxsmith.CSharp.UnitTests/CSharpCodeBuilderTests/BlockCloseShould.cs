﻿namespace Syntaxsmith.CSharp.UnitTests.CSharpCodeBuilderTests;

[TestClass]
public class BlockCloseShould
{
    [TestMethod]
    public void AddBraceGivenOnlyOne()
    {
        var builder = new CSharpCodeBuilder();
        builder.BlockClose();
        Assert.AreEqual("}", builder.ToString());
    }

    [TestMethod]
    public void AddsExtraLineGivenNextLineNotAnotherBlockClose()
    {
        var builder = new CSharpCodeBuilder();
        builder.BlockClose();
        builder.AddLine("public class Test");
        var expected = """
            }

            public class Test
            """;

        Assert.AreEqual(expected, builder.ToString());
    }

    [TestMethod]
    public void DoesNotAddExtraLineGivenNextLineIsAnotherBlockClose()
    {
        var builder = new CSharpCodeBuilder();
        builder.BlockOpen();
        builder.BlockOpen();
        builder.BlockClose();
        builder.BlockClose();
        var expected = """
            {
                {
                }
            }
            """;

        Assert.AreEqual(expected, builder.ToString());
    }

    [TestMethod]
    public void NotReduceIndentLevelGivenAtZero()
    {
        var builder = new CSharpCodeBuilder();
        builder.BlockClose();
        Assert.AreEqual(0, builder.Context.IndentLevel);
    }

    [TestMethod]
    public void ReduceIndentLevelGivenAtOne()
    {
        var builder = new CSharpCodeBuilder();
        builder.Context.IndentLevel++;
        builder.BlockClose();
        Assert.AreEqual(0, builder.Context.IndentLevel);
    }
}