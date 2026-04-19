namespace Pure.SQLiteRepository;

public interface ISQLiteConnectionSetting
{
    public string? DataSource { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int ForeignKeys { get; set; }
}
