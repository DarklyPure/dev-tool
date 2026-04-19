namespace Pure.Library.SQLite.Extensions.Utilities;

public class EnvironmentSettings
{
    public string? DatabaseName { get; set; }
    public string? Version { get; set; }
    public string? InstallPath { get; set; }
    public string? ArchivePath { get; set; }
    public string? BackupPath { get; set; }
    public List<string> CurrentTableList { get; set; } = [];
}
