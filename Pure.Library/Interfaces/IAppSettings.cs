namespace Pure.Library.Interfaces;

/// <summary>
/// Interface for the consuming the appsettings.json file.
/// </summary>
public interface IAppSettings
{
    public string ApplicationName { get; set; }
    public string ApplicationVersion { get; set; }
    public string ApplicationDescription { get; set; }
    public string ApplicationRootDirectory { get; set; }
    public string LogsDirectory { get; set; }
}
