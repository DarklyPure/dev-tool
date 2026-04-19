namespace Pure.Dal.Coders.Toolbox.Entities;

public partial class MethodSpecification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ClassId { get; set; } = string.Empty;
    public string Modifier { get; set; } = ModifierNames.Public;
    public string Name { get; set; } = string.Empty;
    public string ReturnType { get; set; } = string.Empty;

    public ClassSpecification? ClassSpecification { get; set; }
    public ICollection<ParameterSpecification> ParameterSpecifications { get; set; } = [];
}
