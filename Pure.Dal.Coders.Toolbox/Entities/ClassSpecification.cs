namespace Pure.Dal.Coders.Toolbox.Entities;

public partial class ClassSpecification
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string AppearsInNamespace { get; set; } = string.Empty;
    public bool IsStatic { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Modifier { get; set; } = ModifierNames.Public;
    public string? NoteId { get; set; }

    public ICollection<MethodSpecification> MethodSpecifications { get; set; } = [];
    public ICollection<PropertySpecification> PropertySpecifications { get; set; } = [];
}
