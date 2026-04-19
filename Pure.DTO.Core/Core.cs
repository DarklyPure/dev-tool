namespace Pure.DTO.Core;

public abstract class Core
{
    /// <summary>
    /// Primary Key - Whereby a primary key is used and not a Row Key
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// The date and time that the item was created
    /// </summary>
    public DateTime Created { get; set; } = DateTime.Now;

    /// <summary>
    /// The username of the account that created the item
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// The date and time that the item was last modified
    /// </summary>
    public DateTime Modified { get; set; } = DateTime.Now;

    /// <summary>
    /// The username of the account that last modified the item
    /// </summary>
    public string? ModifiedBy { get; set; }

    private string? _PartitionKey;
    /// <summary>
    /// The partition key - Becomes part of the primary key - can be duplicated
    /// </summary>
    public string? PartitionKey
    {
        get => _PartitionKey;
        set => _PartitionKey = (!string.IsNullOrEmpty(value)) ? value.ToLower() : value;
    }

    private string? _RowKey;
    /// <summary>
    /// The row key - Becomes part of the primary key - Must be unique
    /// </summary>
    public string? RowKey
    {
        get => _RowKey;
        set => _RowKey = (!string.IsNullOrEmpty(value)) ? value.ToLower() : value;
    }

    /// <summary>
    /// NoSQL/Table Storage Timestamp
    /// </summary>
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.Now;

    /// <summary>
    /// The ETag works as a concurrency check. When updating a record update against
    /// <see cref="PartitionKey"/>, <see cref="RowKey"/> and <see cref="ETag"/>.
    /// </summary>
    public string? ETag { get; set; }

    /// <summary>
    /// Maps to an MSSQL Timestamp field providing concurrency checking
    /// </summary>
    public byte[]? ConcurrencyTimestamp { get; set; }

    /// <summary>
    /// A dictionary, containing meta data.
    /// </summary>
    public Dictionary<string, string> MetaData { get; set; } = [];
}
