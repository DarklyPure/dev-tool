using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

public partial class Plantae
{
    [Required] public string Genus { get; set; } = string.Empty;

    [Required] public string Species { get; set; } = string.Empty;

    [Required] public string CommonName { get; set; } = string.Empty;
}
