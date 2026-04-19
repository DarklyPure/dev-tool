namespace Pure.BO.Coders;

/// <summary>
/// Business Object - Details a "flavour" of code.
/// </summary>
public partial class CodeFlavour
{
    /// <summary>
    /// The name of the code language.
    /// </summary>
    /// <example>
    /// C#
    /// </example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The extenion to use with these code files.
    /// </summary>
    /// <example>
    /// .cs
    /// </example>
    public string Extension { get; set; } = string.Empty;

    /// <summary>
    /// Optional - a description regarding the "flavour".
    /// </summary>
    /// <example>
    /// The C# language.
    /// </example>
    public string? Description { get; set; }
}
