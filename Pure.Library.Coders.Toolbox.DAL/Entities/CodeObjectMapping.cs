using System.ComponentModel.DataAnnotations;

namespace Pure.Library.Coders.Toolbox.DAL.Entities;

public partial class CodeObjectMapping
{
    [Required] public string CodeFlavour { get; set; } = string.Empty;
    [Required] public string InputType { get; set; } = string.Empty;
    [Required] public string CodeObject { get; set; } = string.Empty;
}
