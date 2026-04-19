namespace Pure.BO.Coders;

public sealed class PropertySpecificationCodeImplementation
{
    #region Properties
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Language { get; set; } = string.Empty;
    public string? ImplementationType { get; set; }
    public string PropertySpecificationId { get; set; } = string.Empty;
    public string? Code { get; set; }
    public bool Lock { get; set; }
    #endregion
}
