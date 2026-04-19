namespace Pure.BO.Coders;

/// <summary>
/// Specification detailing a method on a class.
/// </summary>
public sealed class MethodSpecification
{
    /// <summary>
    /// The primary key.
    /// </summary>
    /// <example>
    /// 1
    /// </example>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The primary key of the <see cref="ClassSpecification"/> that this belongs to.
    /// </summary>
    /// <example>
    /// 1
    /// </example>
    public string ClassId { get; set; } = string.Empty;

    /// <summary>
    /// The modifier.
    /// </summary>
    /// <example>
    /// public
    /// </example>
    public string Modifier { get; set; } = string.Empty;

    /// <summary>
    /// The name of the method.
    /// </summary>
    /// <example>
    /// MethodOne
    /// </example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The return <see cref="Type"/> where is not a void.
    /// </summary>
    /// <example>
    /// string
    /// </example>
    public string ReturnType { get; set; } = string.Empty;

    /// <summary>
    /// The <see cref="ParameterSpecification"/> collection that belong to this method.
    /// </summary>
    public ICollection<ParameterSpecification> ParameterSpecifications { get; set; } = [];

    /// <summary>
    /// Optional - A note regarding this <see cref="MethodSpecification"/>.
    /// </summary>
    /// <example>
    /// This is a note.
    /// </example>
    public string? Note { get; set; }
}
