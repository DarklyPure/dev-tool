namespace Pure.BO.Core;

public class FileLocation
{
    /// <summary>
    /// The primary key
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the file.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The location type.
    /// </summary>
    public string? LocationType { get; set; }

    /// <summary>
    /// The fully qualified path to the file.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// A description.
    /// </summary>
    public string? Description { get; set; }
}
