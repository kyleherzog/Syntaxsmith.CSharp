using System.Text;

namespace Syntaxsmith.CSharp;

/// <summary>
/// Provides a context for building a block of syntax formatted text.
/// </summary>
public class SyntaxContext
{
    private readonly StringBuilder builder = new();
    private int indentLevel;

    public SyntaxContext(string indentValue = "    ")
    {
        IndentValue = indentValue;
    }

    /// <summary>
    /// Gets or sets the current indent level. This value cannot go below zero.
    /// </summary>
    public int IndentLevel { get => indentLevel; set => indentLevel = value < 0 ? 0 : value; }

    /// <summary>
    /// Gets the string value used for each level of indentation.
    /// </summary>
    public string IndentValue { get; }

    /// <summary>
    /// Gets a value indicating whether the context has any content.
    /// </summary>
    public bool HasContent => builder.Length > 0;

    /// <summary>
    /// Gets or a sets a name for the last operation performed on the context. This gets reset upon each addition of text.
    /// </summary>
    public string LastOperationName { get; set; } = string.Empty;


    /// <summary>
    /// A value indicating whether the insertion of a line break is waiting to be applied until the next addition of text.
    /// </summary>
    public bool IsPendingLineClose { get; set; }

    /// <summary>
    /// Adds the specified text to the current line. If a line is pending close, a new line is added first.
    /// </summary>
    /// <param name="text">The text to be added to the current line.</param>
    public void Add(string? text)
    {
        if (IsPendingLineClose)
        {
            builder.AppendLine();
            IsPendingLineClose = false;
        }

        if (text is null)
        {
            return;
        }

        builder.Append(text);
        LastOperationName = string.Empty;
    }

    /// <summary>
    /// Adds the specified text to a new line, which is indented one level more than the current indent level.
    /// </summary>
    /// <param name="text">The text to be applied to the line.</param>
    /// <param name="extraIndentLevels">
    /// An optional value indicate additional indent levels to be applied to the new line in addition
    /// to the one extra level to be applied.  This indent level will not be persisted.
    /// </param>
    public void AddChildLine(string? text, int extraIndentLevels = 0)
    {
        extraIndentLevels = extraIndentLevels < 0 ? 0 : extraIndentLevels;
        AddLine(text, extraIndentLevels + 1);
    }

    /// <summary>
    /// Adds a new complete line of text, which is indented to the level of the current indent level plus any extra indent levels specified.
    /// </summary>
    /// <param name="text">The text to be applied to the line.</param>
    /// <param name="extraIndentLevels">An optional value to indicate additional indent levels to be applied to the new line.  This indent level will not be persisted.</param>
    public void AddLine(string? text = null, int extraIndentLevels = 0)
    {
        if (!string.IsNullOrWhiteSpace(text))
        {
            LineOpen(extraIndentLevels);
        }

        Add(text);
        LineClose();
    }

    /// <summary>
    /// Closes the current line to additional text.
    /// </summary>
    public void LineClose()
    {
        IsPendingLineClose = true;
    }

    /// <summary>
    /// Opens a new line by adding the current indent level text.
    /// </summary>
    /// <param name="extraIndentLevels">An optional value to indicate additional indent levels to be applied to the new line.  This indent level will not be persisted.</param>
    public void LineOpen(int extraIndentLevels = 0)
    {
        for (var i = 0; i < IndentLevel + extraIndentLevels; i++)
        {
            Add(IndentValue);
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return builder.ToString().TrimEnd();
    }
}