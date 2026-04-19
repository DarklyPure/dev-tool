namespace Pure.Dal.Coders.Toolbox.Entities;

/// <summary>
/// Entity - Models a "Flavour" of code.
/// </summary>
public partial class CodeFlavour
{
    /// <summary>
    /// The name of the code "Flavour".
    /// </summary>
    /// <example>
    /// C#
    /// </example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The extension.
    /// </summary>
    /// <example>
    /// .cs
    /// </example>
    public string Extensions { get; set; } = string.Empty;

    /// <summary>
    /// Optional - A description regarding the code "Flavour".
    /// </summary>
    public string? Description { get; set; }
}
