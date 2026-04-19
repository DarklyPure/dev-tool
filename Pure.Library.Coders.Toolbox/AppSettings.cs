
using Pure.Library.Interfaces;

namespace Pure.Library.Coders.Toolbox;

public class AppSettings : IAppSettings
{
    public string ApplicationName { get; set; } = string.Empty;
    public string ApplicationVersion { get; set; } = string.Empty;
    public string ApplicationDescription { get; set; } = string.Empty;
    public string ApplicationRootDirectory { get; set; } = string.Empty;
    public string LogsDirectory { get; set; } = string.Empty;
    public string ImportsDirectory { get; set; } = string.Empty;
    public string ExportsDirectory { get; set; } = string.Empty;
    public string DatabaseDirectory { get; set; } = string.Empty;
    public SQLiteSettings? SQLiteSettings { get; set; }
}

public class SQLiteSettings
{
    public string? DatabaseName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Version { get; set; }
    public string? VersionDate { get; set; }
}
