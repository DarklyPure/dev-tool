namespace Pure.Library.SQLite.Extensions.Entities;

public partial class SystemDetail
{
    public string Application { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Value { get; set; }
    public string Created { get; set; } = string.Empty;
    public string Updated { get; set; } = string.Empty;
}
