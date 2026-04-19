namespace Pure.Library.Repository.Interfaces;

/// <summary>
/// Interface for creating a SQL based entity.
/// </summary>
public interface IEntitySQL
{
    public int Id { get; set; }
    /// <summary>
    /// Maps to an MSSQL Timestamp field providing concurrency checking
    /// </summary>
    public byte[]? ConcurrencyTimestamp { get; set; }
}
