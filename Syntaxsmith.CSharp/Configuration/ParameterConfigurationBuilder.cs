using Syntaxsmith.CSharp.Enums;
using Syntaxsmith.CSharp.Extensions;

namespace Syntaxsmith.CSharp.Configuration;

public class ParameterConfigurationBuilder
{
    public ParameterConfigurationBuilder(string type, string name)
    {
        Configuration = new ParameterConfiguration(type, name);
    }

    internal ParameterConfiguration Configuration { get; }

    public ParameterConfigurationBuilder As<T>()
    {
        return As(typeof(T).FriendlyName());
    }

    public ParameterConfigurationBuilder As(string type)
    {
        Configuration.Type = type;
        return this;
    }

    public ParameterConfigurationBuilder In()
    {
        Configuration.Keyword = ParameterKeyword.In;
        return this;
    }

    public ParameterConfigurationBuilder Out()
    {
        Configuration.Keyword = ParameterKeyword.Out;
        return this;
    }

    public ParameterConfigurationBuilder Ref()
    {
        Configuration.Keyword = ParameterKeyword.Ref;
        return this;
    }

    public ParameterConfigurationBuilder This()
    {
        Configuration.Keyword = ParameterKeyword.This;
        return this;
    }

    public ParameterConfigurationBuilder Params()
    {
        Configuration.Keyword = ParameterKeyword.Params;
        return this;
    }
}