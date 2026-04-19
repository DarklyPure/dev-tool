namespace Pure.Dal.Coders.Toolbox.Entities;

public partial class NoteContent
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string NoteId { get; set; } = string.Empty;
    public byte[]? Body { get; set; }

    public Note? Note { get; set; }
}
