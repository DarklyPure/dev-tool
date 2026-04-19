using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

/// <summary>
/// Entity models a Genus entry.
/// </summary>
public class GenusName
{
    [Required] public string Name { get; set; } = string.Empty;
    public int Note { get; set; }
    [Required] public DateTime Created { get; set; }
    [Required] public string CreatedBy { get; set; } = string.Empty;
    [Required] public DateTime Modified { get; set; }
    [Required] public string ModifiedBy { get; set; } = string.Empty;
}
