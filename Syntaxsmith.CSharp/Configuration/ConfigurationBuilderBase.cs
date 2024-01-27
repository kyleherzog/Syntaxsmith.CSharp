using Syntaxsmith.CSharp.Interfaces;

namespace Syntaxsmith.CSharp.Configuration;

public abstract class ConfigurationBuilderBase
{
    internal abstract IConfigurationFormatter ConfigurationFormatter { get; }
}
