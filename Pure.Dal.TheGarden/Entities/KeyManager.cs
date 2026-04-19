using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

/// <summary>
/// An entity model. Manages the primary keys in this database.
/// </summary>
public partial class KeyManager
{
    /// <summary>
    /// The name of the table the item is stored in.
    /// </summary>
    [Required] public string TableName { get; set; } = string.Empty;

    /// <summary>
    /// The key where it's an integer.
    /// </summary>
    public int KeyInt { get; set; }

    /// <summary>
    /// The key it's a string.
    /// </summary>
    public string KeyString { get; set; } = string.Empty;

    /// <summary>
    /// The key where it's a composite.
    /// </summary>
    public string KeyComposite { get; set; } = string.Empty;

    /// <summary>
    /// The global key.
    /// </summary>
    /// <remarks>
    /// This gives portability to this record.
    /// </remarks>
    [Required] public string GlobalKey { get; set; } = string.Empty;

    /// <summary>
    /// The date this key was created.
    /// </summary>
    [Required] public string Created { get; set; } = string.Empty;

    /// <summary>
    /// The account that created this key.
    /// </summary>
    [Required] public string CreatedBy { get; set; } = string.Empty;
}
