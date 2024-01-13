namespace Syntaxsmith.CSharp;

public class XmlDocsBuilder : SyntaxBuilder<XmlDocsBuilder>
{
    public XmlDocsBuilder(SyntaxContext? context = null)
        : base(context)
    {
    }

    public XmlDocsBuilder AddSummary(string summary)
    {
        AddLine($"/// <summary>");
        AddLine($"/// {summary}");
        AddLine($"/// </summary>");
        return this;
    }

    public XmlDocsBuilder AddParam(string name, string description)
    {
        AddLine($"/// <param name=\"{name}\">{description}</param>");
        return this;
    }

    public XmlDocsBuilder AddReturns(string description)
    {
        AddLine($"/// <returns>{description}</returns>");
        return this;
    }
}