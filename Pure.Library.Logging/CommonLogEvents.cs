using Microsoft.Extensions.Logging;

namespace Pure.Library.Logging;

public static partial class CommonLogEvents
{
    /// <summary>
    /// Information Log entry. Specifies that an application is starting.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="timestamp">The date and time that the application started.</param>
    [LoggerMessage(EventId = 5000, Level = LogLevel.Information, Message = "Application Starting at {timestamp}")]
    public static partial void ApplicationStarting(this ILogger logger, DateTime timestamp);

    /// <summary>
    /// Information Log entry. Specifies that an application is stopping.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="timestamp">The date and time that the application stopped.</param>
    [LoggerMessage(EventId = 5001, Level = LogLevel.Information, Message = "Application Stopped {timestamp}")]
    public static partial void ApplicationStopping(this ILogger logger, DateTime timestamp);

    /// <summary>
    /// Information Log Entry. Specifies the commencement of processing.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="timestamp">The date and time that the processing started.</param>
    [LoggerMessage(EventId = 1001, Level = LogLevel.Information, Message = "Processing {processName} started at {timestamp}")]
    public static partial void ProcessingStarted(this ILogger logger, DateTime timestamp, string processName = "");

    [LoggerMessage(EventId = 1002, Level = LogLevel.Information, Message = "Reached stage {stage} at: {timestamp} - {note}")]
    public static partial void ProcessingStage(this ILogger logger, DateTime timestamp, string stage, string note = "");
    /// <summary>
    /// Information Log entry. Specifies the completion of the processing.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="timestamp">The date and time that the processing completed.</param>
    [LoggerMessage(EventId = 1002, Level = LogLevel.Information, Message = "Processing {processName} completed at {timestamp}")]
    public static partial void ProcessingCompleted(this ILogger logger, DateTime timestamp, string processName = "");

    /// <summary>
    /// Error log entry. Specifies that the processing has failed.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="errorMessage">The error message.</param>
    [LoggerMessage(EventId = 1003, Level = LogLevel.Error, Message = "Processing {processName} failed: {ErrorMessage}")]
    public static partial void ProcessingFailed(this ILogger logger, string errorMessage, string processName = "");

    /// <summary>
    /// Information log entry. Specifies the searched for item was found.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="item">The details of the item being searched for.</param>
    [LoggerMessage(EventId = 1020, Level = LogLevel.Information, Message = "Found {item}")]
    public static partial void ItemFound(this ILogger logger, string item);

    /// <summary>
    /// Information log entry. Specifies the searched for item was found.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="item">The details of the item being searched for.</param>
    /// <param name="destination">The destination of the file.</param>
    [LoggerMessage(EventId = 1020, Level = LogLevel.Information, Message = "Moved {item} to {destination}")]
    public static partial void ItemMoved(this ILogger logger, string item, string destination);

    /// <summary>
    /// Information log entry. Specifies that the item wasn't found.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    [LoggerMessage(EventId = 1021, Level = LogLevel.Information, Message = "Item not found")]
    public static partial void NoItemFound(this ILogger logger);

    /// <summary>
    /// Error log entry. Specifies that there is a high memory usage.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    /// <param name="memoryUsageMB">The Memory usage in megabytes.</param>
    [LoggerMessage(EventId = 1090, Level = LogLevel.Warning, Message = "High memory usage detected: {MemoryUsageMB}MB")]
    public static partial void HighMemoryUsage(this ILogger logger, long memoryUsageMB);

    /// <summary>
    /// Error log entry. Specifies that an exception has occurred.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> instance.</param>
    [LoggerMessage(EventId = 1091, Level = LogLevel.Error, Message = "{message}")]
    public static partial void LogException(this ILogger logger, Exception exception, string message);
}
