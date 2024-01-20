﻿namespace Syntaxsmith.CSharp.Configuration;

internal class CSharpFileConfiguration
{
    public List<(PreprocessorDirective Directive, string? Text)> Directives { get; } = [];

    public bool IsAddingAutoGeneratedComment { get; set; } = true;
}