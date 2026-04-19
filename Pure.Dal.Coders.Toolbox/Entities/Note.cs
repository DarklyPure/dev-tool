namespace Pure.Dal.Coders.Toolbox.Entities;

public partial class Note
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Description { get; set; } = string.Empty;
    public string NoteContentId { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime Updated { get; set; } = DateTime.Now;
    public string UpdatedBy { get; set; } = string.Empty;
    public bool IsClosed { get; set; }

    public NoteContent? NoteContent { get; set; }
}
