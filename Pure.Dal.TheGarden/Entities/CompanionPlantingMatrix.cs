using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

public class CompanionPlantingMatrix
{
    [Required] public int Id { get; set; }

    [Required] public string Genus { get; set; } = string.Empty;

    [Required] public string Species { get; set; } = string.Empty;

    [Required] public string CommonName { get; set; } = string.Empty;
}
