using System.ComponentModel.DataAnnotations;

namespace Pure.Dal.TheGarden.Entities;

/// <summary>
/// Entity model. Models Look-Up/List items.
/// </summary>
public partial class LookUp
{
    /// <summary>
    /// The primary key.
    /// </summary>
    [Required] public int Id { get; set; }

    /// <summary>
    /// Optiional - The Primary Key of the parent.
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// The name of the Look-Up/List item.
    /// </summary>
    [Required] public string? Name { get; set; }

    /// <summary>
    /// The value of the Look-Up/List item.
    /// </summary>
    /// <remarks>
    /// Use this whereby the list represents an external item
    /// and you wish to patch that key into here.
    /// </remarks>
    public string? Value { get; set; }

    /// <summary>
    /// The Text to display.
    /// </summary>
    [Required] public string? Text { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Note { get; set; }
    public bool Archive { get; set; }
}
