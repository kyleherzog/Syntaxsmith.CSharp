namespace Syntaxsmith.CSharp;

public abstract class NamespaceBuilder<T> : CSharpCodeBuilder<T> where T : NamespaceBuilder<T>
{
    protected NamespaceBuilder(string typeName, SyntaxContext? context = null)
        : base(context)
    {
        TypeName = typeName
            ?? throw new ArgumentNullException(nameof(typeName));
    }

    public string TypeName { get; }

    public T AddUsings(params string[] namespaces)
    {
        foreach (var value in namespaces)
        {
            AddLine($"using {value};");
        }

        AddLine();
        return (T)this;
    }

    public T AddNamespace(string value)
    {
        AddLine($"namespace {value};");
        AddLine();
        return (T)this;
    }

    public T Close()
    {
        return BlockClose();
    }
}