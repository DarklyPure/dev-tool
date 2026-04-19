using System.ComponentModel.DataAnnotations;

namespace Pure.BO.Coders;

/// <summary>
/// Matrix showing code objects that can be generated.
/// </summary>
public partial class CodeObjectMatrix
{
    /// <summary>
    /// The "flavour" of code.
    /// </summary>
    /// <example>
    /// C#
    /// </example>
    [Required] public string CodeFlavour { get; set; } = string.Empty;

    /// <summary>
    /// The input type.
    /// </summary>
    /// <example>
    /// Type
    /// </example>
    [Required] public string InputType { get; set; } = string.Empty;

    /// <summary>
    /// The code object.
    /// </summary>
    /// <example>
    /// Builder
    /// </example>
    [Required] public string CodeObject { get; set; } = string.Empty;
}
