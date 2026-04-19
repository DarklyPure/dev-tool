using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

/// <summary>
/// Entity model. Represents a note. Specifically the summary of a note.
/// </summary>
public partial class Note
{
    /// <summary>
    /// The primary key.
    /// </summary>
    /// <example>
    /// 1
    /// </example>
    [Required] public int Id { get; set; }

    /// <summary>
    /// Foreign Key - The primary key of the Note Content.
    /// </summary>
    /// <remarks>
    /// Optional - For when the note gets verbose.
    /// </remarks>
    [Required] public int NoteContentId { get; set; } = 0;

    /// <summary>
    /// A short 256 character (maximum) summary of what the note is about.
    /// </summary>
    /// <example>
    /// This is a note.
    /// </example>
    [Required] public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// The date and time the note was created.
    /// </summary>
    [Required] public string Created { get; set; } = DateTime.Now.ToString();

    /// <summary>
    /// The name of the account that created the note.
    /// </summary>
    [Required] public string CreatedBy { get; set; } = string.Empty;

    public int Delete { get; set; } = 0;
}
