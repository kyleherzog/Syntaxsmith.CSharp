using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class XmlDocsConfigurationBuilder
{
    internal XmlDocsConfiguration Configuration { get; } = new();

    public XmlDocsConfigurationBuilder AddException(string type, string description)
    {
        Configuration.Exceptions.Add((type, description));
        return this;
    }

    public XmlDocsConfigurationBuilder AddException(Type type, string description)
    {
        return AddException(type.FriendlyName(), description);
    }

    public XmlDocsConfigurationBuilder AddException<T>(string description)
        where T : Exception
    {
        return AddException(typeof(T), description);
    }

    public XmlDocsConfigurationBuilder AddParam(string name, string description)
    {
        Configuration.Parameters.Add((name, description));
        return this;
    }

    public XmlDocsConfigurationBuilder Inherits()
    {
        Configuration.IsInherit = true;
        return this;
    }

    public XmlDocsConfigurationBuilder Returns(string description)
    {
        Configuration.Returns = description;
        return this;
    }

    public XmlDocsConfigurationBuilder Summary(string description)
    {
        Configuration.Summary = description;
        return this;
    }

    public void AppendToContext(SyntaxContext context)
    {
        Configuration.AppendToContext(context);
    }
}