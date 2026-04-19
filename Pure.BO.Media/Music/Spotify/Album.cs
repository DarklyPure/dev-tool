using System.Text.Json.Serialization;

namespace Pure.BO.Media.Music.Spotify;

public class Album
{
    [JsonPropertyName("Album_Type")]
    public string? AlbumType { get; set; }
    [JsonPropertyName("Total_Tracks")]
    public int? TotalTracks { get; set; }
    [JsonPropertyName("Available_Markets")]
    public string[]? AvailableMarkets { get; set; }
    [JsonPropertyName("External_Urls")]
    public ExternalUrl[]? External_Urls { get; set; }
    public string? Href { get; set; }
    public string? Id { get; set; }
    public Image[]? Images { get; set; }
    public string? Name { get; set; }
    [JsonPropertyName("Release_Date")]
    public string? ReleaseDate { get; set; }
    [JsonPropertyName("Release_Date_Precision")]
    public string? ReleaseDatePrecision { get; set; }
    public Restriction[]? Restrictions { get; set; }
    public string? Type { get; set; }
    public string? Uri { get; set; }
    public Artist[]? Artists { get; set; }
}
