namespace Pure.Dal.Coders.Toolbox.Entities;

public class PropertySpecification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ClassId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool IsNumeric { get; set; }
    public bool IsDate { get; set; }
    public bool IsCollection { get; set; }

    public ClassSpecification? ClassSpecification { get; set; }
    public ICollection<PropertySpecificationCodeImplementation>? PropertySpecificationCodeImplementations { get; set; }
}
