namespace Pure.Dal.Coders.Toolbox.Entities;

public partial class PropertySpecificationCodeImplementation
{
    #region Properties
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string PropertySpecificationId { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string? ImplementationType { get; set; }
    public byte[]? Code { get; set; }
    public bool Lock { get; set; }
    public PropertySpecification? PropertySpecification { get; set; }
    #endregion
}
