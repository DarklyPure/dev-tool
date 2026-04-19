using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

public partial class NoteContent
{
    [Required] public int Id { get; set; }
}
