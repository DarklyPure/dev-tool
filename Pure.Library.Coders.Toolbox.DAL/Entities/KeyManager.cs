using System.ComponentModel.DataAnnotations;

namespace Pure.Library.Coders.Toolbox.DAL.Entities;

public partial class KeyManager
{
    [Required] public string TableName { get; set; } = string.Empty;

    public int KeyInt {  get; set; }
    public string KeyString { get; set; } = string.Empty;

    public string KeyComposite {  get; set; } = string.Empty;
    [Required] public string GlobalKey {  get; set; } = string.Empty;

    [Required] public string Created {  get; set; } = string.Empty;

    [Required] public string CreatedBy { get; set; } = string.Empty;
}
