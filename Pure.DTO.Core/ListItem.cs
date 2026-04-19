namespace Pure.DTO.Core;

public sealed class ListItem : Core
{
    public int ParentId { get; set; }
    public int DisplayOrder { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
