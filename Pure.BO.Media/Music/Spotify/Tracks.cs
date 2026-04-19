namespace Pure.BO.Media.Music.Spotify;

public class Tracks
{
    public string? Href { get; set; }
    public int? Limit { get; set; }
    public string? Next { get; set; }
    public int? Offset { get; set; }
    public string? Previous { get; set; }
    public int? Total { get; set; }
    public Item[]? Items { get; set; }
}
