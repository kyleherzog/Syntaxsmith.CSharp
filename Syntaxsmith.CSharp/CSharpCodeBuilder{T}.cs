using Syntaxsmith.CSharp.Configuration;
using Syntaxsmith.CSharp.Enums;

namespace Syntaxsmith.CSharp;

public abstract class CSharpCodeBuilder<T> : SyntaxBuilder<CSharpCodeBuilder<T>> where T : CSharpCodeBuilder<T>
{
    protected CSharpCodeBuilder(SyntaxContext? context = null)
        : base(context)
    {
    }

    public T AddCommentLine(string comment)
    {
        Context.AddLine($"// {comment}");
        return (T)this;
    }

    public T AddDirective(PreprocessorDirective dirctive, string? text = null)
    {
        // start a new line if there is content
        if (Context.HasContent)
        {
            Context.IsPendingLineClose = true;
        }

        Context.Add("#");
        Context.Add(dirctive.DirectiveText());
        if (!string.IsNullOrWhiteSpace(text))
        {
            Context.Add(" ");
            Context.Add(text);
        }

        Context.LineClose();
        return (T)this;
    }

    public T AddXmlDocs(Action<XmlDocsConfigurationBuilder>? configAction)
    {
        if (configAction is null)
        {
            throw new ArgumentNullException(nameof(configAction));
        }

        var builder = new XmlDocsConfigurationBuilder();
        configAction(builder);

        builder.AppendToContext(Context);
        return (T)this;
    }

    public T BlockClose()
    {
        if (Context.LastOperationName == nameof(BlockClose))
        {
            Context.IsPendingLineClose = false;
        }
        Context.IndentLevel--;
        AddLine("}");
        AddLine(string.Empty); // force line break
        Context.LineClose(); // queue line close for a blank line if not another block close next
        Context.LastOperationName = nameof(BlockClose);
        return (T)this;
    }

    public T BlockOpen()
    {
        AddLine("{");
        Context.IndentLevel++;
        return (T)this;
    }

    public T ClassClose()
    {
        return BlockClose();
    }

    public T ClassOpen(string className, Action<ClassConfigurationBuilder>? configAction = null)
    {
        var builder = new ClassConfigurationBuilder(className);

        if (configAction is not null)
        {
            configAction(builder);
        }

        builder.AppendToContext(Context);

        BlockOpen();
        return (T)this;
    }

    public T EnumClose()
    {
        return BlockClose();
    }

    public T EnumOpen(string enumName, Action<EnumConfigurationBuilder>? configAction = null)
    {
        var builder = new EnumConfigurationBuilder(enumName);

        if (configAction is not null)
        {
            configAction(builder);
        }

        builder.AppendToContext(Context);

        BlockOpen();
        return (T)this;
    }

    public T InterfaceClose()
    {
        BlockClose();
        return (T)this;
    }

    public T InterfaceOpen(string interfaceName, Action<InterfaceConfigurationBuilder>? configAction = null)
    {
        var builder = new InterfaceConfigurationBuilder(interfaceName);

        if (configAction is not null)
        {
            configAction(builder);
        }

        builder.AppendToContext(Context);

        BlockOpen();
        return (T)this;
    }

    public T StructClose()
    {
        return BlockClose();
    }

    public T StructOpen(string structName, Action<StructConfigurationBuilder>? configAction = null)
    {
        var builder = new StructConfigurationBuilder(structName);

        if (configAction is not null)
        {
            configAction(builder);
        }

        builder.AppendToContext(Context);

        BlockOpen();
        return (T)this;
    }
}