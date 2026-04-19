namespace Pure.Dal.Coders.Toolbox.Entities;

public partial class ParameterSpecification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string MethodId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool ByRef { get; set; }

    public MethodSpecification? MethodSpecification { get; set; }
}
