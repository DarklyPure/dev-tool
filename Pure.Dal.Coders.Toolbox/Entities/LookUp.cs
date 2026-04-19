namespace Pure.Dal.Coders.Toolbox.Entities;

/// <summary>
/// Entity - Models a list/look-up item.
/// </summary>
public partial class LookUp
{
    /// <summary>
    /// The primary key.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The primary key of the parent, where this isn't a parent.
    /// </summary>
    public int ParentId { get; set; }

    /// <summary>
    /// The name of the list item or the name of the list.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The value.
    /// </summary>
    /// <remarks>
    /// The value, whereby this models a third party item.
    /// </remarks>
    public string? Value { get; set; }

    /// <summary>
    /// The text to display.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// A note regarding what this represents.
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Marks this as archived.
    /// </summary>
    public bool Archive { get; set; }
}
