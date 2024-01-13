namespace Syntaxsmith.CSharp;

public abstract class CSharpCodeBuilder<T> : SyntaxBuilder<CSharpCodeBuilder<T>> where T : CSharpCodeBuilder<T>
{
    protected CSharpCodeBuilder(SyntaxContext? context = null)
        : base(context)
    {
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
}