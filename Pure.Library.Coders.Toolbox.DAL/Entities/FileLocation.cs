namespace Pure.Library.Coders.Toolbox.DAL.Entities;

public partial class FileLocation
{
    public int Id { get; set; }
    public string? LocationType { get; set; }
    public string? Path { get; set; }
    public string? Description { get; set; }
}
