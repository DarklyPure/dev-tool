using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Pure.Library.Logging.Loggers;

/// <summary>
/// An asynchronous <see cref="ILogger"/> implementation.
/// </summary>
/// <param name="categoryName">The name of category.</param>
/// <param name="logQueue">A <see cref="BlockingCollection{LogEntry}"/> collection, containing Logs.</param>
public sealed class AsyncFileLogger(string categoryName, BlockingCollection<LogEntry> logQueue) : ILogger
{
    private readonly string _categoryName = categoryName;
    private BlockingCollection<LogEntry> _logQueue = logQueue;

    IDisposable? ILogger.BeginScope<TState>(TState state) => NullScope.Instance;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

    /// <summary>
    /// Creates a Log.
    /// </summary>
    /// <typeparam name="TState">The state.</typeparam>
    /// <param name="logLevel">The <see cref="LogLevel"/> being logged.</param>
    /// <param name="eventId">The <see cref="EventId"/>.</param>
    /// <param name="state">The state.</param>
    /// <param name="exception">Optional. The <see cref="Exception"/> instance.</param>
    /// <param name="formatter">The function for formatting the log.</param>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) { return; }

        LogEntry entry = new()
        {
            Timestamp = DateTime.UtcNow,
            Level = logLevel.ToString(),
            Category = _categoryName,
            EventId = eventId.Id,
            Message = formatter(state, exception),
            Exception = exception?.ToString()
        };

        try
        {
            // Non-blocking add with fallback
            if (!_logQueue.TryAdd(entry, 100)) // 100ms timeout
            {
                // Queue is full - could implement fallback strategies here
                Console.WriteLine($"[WARNING] Log queue full, dropping message: {entry.Message}");
            }
        }
        catch (Exception)
        {

        }

    }

    private sealed class NullScope : IDisposable
    {
        public static readonly NullScope Instance = new();
        public void Dispose() { }
    }
}
