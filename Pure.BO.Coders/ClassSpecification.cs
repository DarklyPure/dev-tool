namespace Pure.BO.Coders;

/// <summary>
/// Business Object - Details the specifics of a class.
/// </summary>
public sealed class ClassSpecification
{
    /// <summary>
    /// The primary key.
    /// </summary>
    /// <example>
    /// 1
    /// </example>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The namespace.
    /// </summary>
    public string AppearsInNamespace { get; set; } = string.Empty;

    /// <summary>
    /// The name of the class.
    /// </summary>
    /// <example>
    /// The class name
    /// </example>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The modifier
    /// </summary>
    /// <example>
    /// public
    /// </example>
    public string Modifier { get; set; } = string.Empty;

    /// <summary>
    /// Optional - A note regarding the class.
    /// </summary>
    /// <example>
    /// This is a note.
    /// </example>
    public string? Note { get; set; }

    /// <summary>
    /// The <see cref="PropertySpecification"/> collection.
    /// </summary>
    /// <example>
    /// 
    /// </example>
    public PropertySpecification[] PropertySpecifications { get; set; } = [];

    /// <summary>
    /// The <see cref="MethodSpecification"/> collection.
    /// </summary>
    /// <example>
    /// 
    /// </example>
    public MethodSpecification[] MethodSpecifications { get; set; } = [];
}
