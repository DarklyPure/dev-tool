namespace Pure.Dal.Coders.Toolbox.Entities;
/// <summary>
/// Entity - Models a the mapping that specifies what can be created.
/// </summary>
public partial class CodeObjectMatrix
{
    /// <summary>
    /// The "Flavour" of code.
    /// </summary>
    /// <example>
    /// C#
    /// </example>
    public string CodeFlavour { get; set; } = string.Empty;

    /// <summary>
    /// The input type.
    /// </summary>
    /// <example>
    /// Type, PropertyInfo.
    /// </example>
    public string InputType { get; set; } = string.Empty;

    /// <summary>
    /// The code object able to be created based on <see cref="CodeFlavour"/> and <see cref="InputType"/>.
    /// </summary>
    public string CodeObject { get; set; } = string.Empty;
}
