using System.ComponentModel.DataAnnotations;

namespace Pure.Library.Coders.Toolbox.DAL.Entities;

public partial class LookUp
{
    [Required] public int Id { get; set; }
    public int ParentId { get; set; }
    [Required] public string? Name { get; set; }
    public string? Value { get; set; }
    [Required] public string? Text { get; set; }
    public string? Note { get; set; }
    public bool Archive { get; set; }
}
