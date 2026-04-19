namespace Pure.Library.SQLite.Extensions;

public class SystemQueries
{
    /// <summary>
    /// Statement for listing all tables in the database
    /// </summary>
    public const string LIST_TABLES = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'";
}

public class SqliteSettingsNames
{
    public const string Root = "SqliteSettings";
    public const string DatabaseName = "DatabaseName";
    public const string ApplicationName = "ApplicationName";
    public const string DatabaseDirectoryName = "DatabaseDirectoryName";
}

