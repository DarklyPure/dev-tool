namespace Pure.Library.Logging;

/// <summary>
/// A Log entry
/// </summary>
public sealed class LogEntry
{
    /// <summary>
    /// The date and time of the log.
    /// </summary>
    public DateTime Timestamp { get; init; }

    /// <summary>
    /// The level of the log.
    /// </summary>
    public string? Level { get; init; }

    /// <summary>
    /// The category of the log.
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// The event identity.
    /// </summary>
    public int EventId { get; init; }

    /// <summary>
    /// The message.
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// The exception.
    /// </summary>
    public string? Exception { get; init; }
}
