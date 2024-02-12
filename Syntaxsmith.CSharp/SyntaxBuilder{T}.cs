namespace Syntaxsmith.CSharp;

public abstract class SyntaxBuilder<T> where T : SyntaxBuilder<T>
{
    protected SyntaxBuilder(SyntaxContext? context = null)
    {
        context ??= new();
        Context = context;
    }

    protected internal SyntaxContext Context { get; set; }

    public T AddChildLine(string text, int extraIndentLevels = 0)
    {
        Context.AddChildLine(text, extraIndentLevels);
        return (T)this;
    }

    public T AddLine(bool condition, string? text = null, int extraIndentLevels = 0)
    {
        if (condition)
        {
            Context.AddLine(text, extraIndentLevels);
        }

        return (T)this;
    }

    public T AddLine(string? text = null, int extraIndentLevels = 0)
    {
        Context.AddLine(text, extraIndentLevels);
        return (T)this;
    }

    public string Build()
    {
        return ToString();
    }

    public override string ToString()
    {
        return Context.ToString().TrimEnd();
    }
}