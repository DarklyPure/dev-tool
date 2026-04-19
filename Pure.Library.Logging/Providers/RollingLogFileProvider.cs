using Microsoft.Extensions.Logging;
using Pure.Library.Logging.Loggers;
using System.Collections.Concurrent;
using System.Text;

namespace Pure.Library.Logging.Providers;

public sealed class RollingFileLoggerProvider : ILoggerProvider
{
    private readonly string _logDirectory;
    private readonly long _maxFileSizeBytes;
    private readonly int _maxFileCount;
    private readonly int _queueCapacity;
    private readonly BlockingCollection<LogEntry> _logQueue;
    private readonly Task _backgroundTask;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly string _appName;
    private long _currentFileSize;
    private readonly ConcurrentDictionary<string, AsyncFileLogger> _loggers = new();

    public RollingFileLoggerProvider(string appName, string logDirectory, long maxFileSizeMB = 50, int maxFileCount = 10, int queueCapacity = 10000)
    {
        _appName = appName;
        _logDirectory = logDirectory;
        _maxFileSizeBytes = maxFileSizeMB * 1024 * 1024;
        _maxFileCount = maxFileCount;
        _queueCapacity = queueCapacity;
        _logQueue = new BlockingCollection<LogEntry>(10000);
        _cancellationTokenSource = new CancellationTokenSource();

        Directory.CreateDirectory(_logDirectory);
        // InitializeWriter();

        _backgroundTask = Task.Run(ProcessLogEntriesAsync);
    }

    public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new AsyncFileLogger(name, _logQueue));

    public void Dispose()
    {
        _logQueue.CompleteAdding();

        try
        {
            _backgroundTask.Wait(TimeSpan.FromSeconds(10), _cancellationTokenSource.Token);
        }
        catch { }

        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
        _logQueue.Dispose();
    }

    private async Task ProcessLogEntriesAsync()
    {
        string logFileName = Path.Combine(_logDirectory, $"{_appName}-{DateTime.UtcNow:yyyy-MM-dd}.log");

        try
        {
            using FileStream fileStream = new(logFileName, FileMode.Append, FileAccess.Write, FileShare.Read);
            using StreamWriter writer = new(fileStream) { AutoFlush = false };

            foreach (LogEntry logEntry in _logQueue.GetConsumingEnumerable(_cancellationTokenSource.Token))
            {
                string logMessage = BuildMessage(logEntry);
                int entryBytes = Encoding.UTF8.GetByteCount(logMessage) + Environment.NewLine.Length;

                // Check if we need to roll to a new file
                if (_currentFileSize + entryBytes > _maxFileSizeBytes)
                {
                    await writer.FlushAsync();
                    writer.Dispose();
                    CleanupOldFiles();
                }

                await writer.WriteLineAsync(logMessage);

                _currentFileSize += entryBytes;

                // Batch flush for better performance
                if (_logQueue.Count == 0)
                {
                    await writer.FlushAsync();
                }
            }
        }
        catch (OperationCanceledException) { } // Expected during shutdown
        catch (Exception ex) { Console.WriteLine($"File logging error: {ex.Message}"); }
    }

    private void CleanupOldFiles()
    {
        IEnumerable<string> logFiles = Directory.GetFiles(_logDirectory, "app-*.log")
                                .OrderByDescending(f => File.GetCreationTime(f))
                                .Skip(_maxFileCount - 1);

        foreach (string file in logFiles)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete old log file {file}: {ex.Message}");
            }
        }
    }

    private string BuildMessage(LogEntry logEntry)
    {
        StringBuilder builder = new();

        builder
            .Append(DateTime.UtcNow)
            .Append(' ')
            .Append('[')
            .Append(logEntry.Level)
            .Append(']')
            .Append(' ');

        if (logEntry.Category != null)
        {
            builder
                .Append('[')
                .Append(logEntry.Category)
                .Append(']')
                .Append(' ');
        }

        builder
            .Append(logEntry.EventId);

        if (logEntry.Message != null)
        {
            builder
                .Append(' ')
                .Append(logEntry.Message);
        }

        if (logEntry.Exception != null)
        {
            builder
                .Append(' ')
                .Append(logEntry.Exception);
        }

        return builder.ToString();
    }
}
