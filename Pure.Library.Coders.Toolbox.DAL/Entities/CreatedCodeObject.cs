namespace Pure.Library.Coders.Toolbox.DAL.Entities;

public partial class CreatedCodeObject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[]? Code { get; set; }
    public int DoNotFluash { get; set; }
}
