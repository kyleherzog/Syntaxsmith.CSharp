﻿using Syntaxsmith.CSharp.Enums;

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

    public T AddCommentLine(string comment)
    {
        Context.AddLine($"// {comment}");
        return (T)this;
    }

}