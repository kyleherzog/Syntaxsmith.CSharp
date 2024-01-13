namespace Syntaxsmith.CSharp.UnitTests.SyntaxContextTests;

[TestClass]
public class ToStringShould
{
    [TestMethod]
    public void ReturnEmptyGivenNoAdds()
    {
        var context = new SyntaxContext();
        Assert.AreEqual(string.Empty, context.ToString());
    }

    [TestMethod]
    public void ReturnCorrectGivenSingleLine()
    {
        var context = new SyntaxContext();
        context.AddLine("public class Test");
        Assert.AreEqual("public class Test", context.ToString());
    }

    [TestMethod]
    public void ReturnCorrectGivenMultipleLines()
    {
        var context = new SyntaxContext();
        context.AddLine("public class Test");
        context.AddLine("{");
        context.AddLine("}");
        var expected = """
            public class Test
            {
            }
            """;
        Assert.AreEqual(expected, context.ToString());
    }

    [TestMethod]
    public void ReturnCorrectGivenMultipleLinesWithIndent()
    {
        var context = new SyntaxContext();
        context.AddLine("public class Test");
        context.AddLine("{");
        context.IndentLevel++;
        context.AddLine("public int Value;");
        context.IndentLevel--;
        context.AddLine("}");
        var expected = """
            public class Test
            {
                public int Value;
            }
            """;
        Assert.AreEqual(expected, context.ToString());
    }

    [TestMethod]
    public void ReturnCorrectGivenMultipleLinesWithIndentAndBlankLines()
    {
        var context = new SyntaxContext();
        context.AddLine("public class Test");
        context.AddLine("{");
        context.IndentLevel++;
        context.AddLine("public int Value;");
        context.AddLine();
        context.AddLine("public int Value2;");
        context.IndentLevel--;
        context.AddLine("}");
        var expected = """
            public class Test
            {
                public int Value;

                public int Value2;
            }
            """;
        Assert.AreEqual(expected, context.ToString());
    }

    [TestMethod]
    public void ReturnCorrectGivenChildLine()
    {
        var context = new SyntaxContext();
        context.AddLine("public void Test(string value)");
        context.AddLine("{");
        context.IndentLevel++;
        context.AddLine("if (true)");
        context.AddChildLine("Console.WriteLine(value);");
        context.IndentLevel--;
        context.AddLine("}");
        var expected = """
            public void Test(string value)
            {
                if (true)
                    Console.WriteLine(value);
            }
            """;
        Assert.AreEqual(expected, context.ToString());
    }

    [TestMethod]
    public void ReturnCorrectGivenExtraIndentLevels()
    {
        var context = new SyntaxContext();
        context.AddLine("public string MyClass(");
        context.AddChildLine("int value,", 1);
        context.AddChildLine("int value2)", 1);


        var expected = """
            public string MyClass(
                    int value,
                    int value2)
            """;
        Assert.AreEqual(expected, context.ToString());
    }
}