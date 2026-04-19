namespace Pure.BO.Coders;

/// <summary>
/// Specification detailing a parameter on a method.
/// </summary>
public sealed class ParameterSpecification
{
    /// <summary>
    /// The primary key.
    /// </summary>
    /// <example>
    /// 1
    /// </example>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The primary key of the <see cref="MethodSpecification"/> that this parameter appears on.
    /// </summary>
    public string MethodId { get; set; } = string.Empty;

    /// <summary>
    /// The name of the parameter.
    /// </summary>
    /// <example>
    /// parameterOne
    /// </example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The <see cref="Type"/> of the parameter.
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Specifies if the parameter uses byRef.
    /// </summary>
    /// <example>
    /// true
    /// </example>
    public bool ByRef { get; set; }

    /// <summary>
    /// Optional - A note regarding the <see cref="ParameterSpecification"/>.
    /// </summary>
    /// <example>
    /// This is a note.
    /// </example>
    public string? Note { get; set; }

    public MethodSpecification? MethodSpecification { get; set; }
}
