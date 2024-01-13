﻿using Syntaxsmith.CSharp.Configuration;

namespace Syntaxsmith.CSharp;

public class InterfaceBuilder : NamespaceBuilder<InterfaceBuilder>
{
    public InterfaceBuilder(string interfaceName, SyntaxContext context, bool enableNullable = true)
        : base(interfaceName, context)
    {
        AddLine("// <autogenerated/>");
        AddLine("#nullable " + (enableNullable ? "enable" : "disable"));

        XmlDocs = new XmlDocsBuilder(Context);
    }

    public XmlDocsBuilder XmlDocs { get; }


    public InterfaceBuilder Open(Action<InterfaceConfigurationBuilder>? configAction = null)
    {
        var builder = new InterfaceConfigurationBuilder(TypeName);

        if (configAction is not null)
        {
            configAction(builder);
        }

        builder.AppendToContext(Context);

        BlockOpen();
        return this;
    }
}