namespace Pure.Library.Repository.Interfaces;

public interface IEntityNoSQL
{
    /// <summary>
    /// The partition key - Becomes part of the primary key - can be duplicated
    /// </summary>
    public string? PartitionKey { get; set; }

    /// <summary>
    /// The row key - Becomes part of the primary key - Must be unique
    /// </summary>
    public string? RowKey { get; set; }

    /// <summary>
    /// NoSQL/Table Storage Timestamp
    /// </summary>
    public DateTimeOffset? Timestamp { get; set; }

    /// <summary>
    /// The ETag works as a concurrency check. When updating a record update against
    /// <see cref="PartitionKey"/>, <see cref="RowKey"/> and <see cref="ETag"/>.
    /// </summary>
    public string? ETag { get; set; }
}
