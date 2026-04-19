using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pure.Library.Logging.Providers;

namespace Pure.Library.Logging.Extensions;

public static class ILoggingBuilderExtensions
{
    /// <summary>
    /// Extension for adding a <see cref="RollingFileLoggerProvider"/> to your dependency injection
    /// </summary>
    /// <param name="builder">The <see cref="ILoggingBuilder"/></param>
    /// <param name="appName">The name of the App.</param>
    /// <param name="logDirectory">The directory in which the logs are stored.</param>
    /// <param name="maxFileSizeMB">The maximum file size before rollover, in MBs.</param>
    /// <param name="maxFileCount">The maximum number of files to maintain.</param>
    /// <returns>The <see cref="ILoggingBuilder"/></returns>
    public static ILoggingBuilder AddRollingLogFile(this ILoggingBuilder builder, string appName, string logDirectory, long maxFileSizeMB = 50, int maxFileCount = 10, int queueCapacity = 10000)
    {
        builder.Services.AddSingleton<ILoggerProvider>(_ => new RollingFileLoggerProvider(appName, logDirectory, maxFileSizeMB, maxFileCount));
        return builder;
    }
}
