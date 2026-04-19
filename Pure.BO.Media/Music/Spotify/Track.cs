using System.Text.Json.Serialization;

namespace Pure.BO.Media.Music.Spotify;

public class Track
{
    public Album? Album { get; set; }
    public Artist[]? Artists { get; set; }
    [JsonPropertyName("Available_Markets")]
    public string[]? AvailableMarkets { get; set; }
    [JsonPropertyName("Disc_Number")]
    public int? DiscNumber { get; set; }
    [JsonPropertyName("Duration_Ms")]
    public int? DurationMs { get; set; }
    [JsonPropertyName("Explicit")]
    public bool? IsExplicit { get; set; }
    [JsonPropertyName("External_Ids")]
    public ExternalIds? ExternalIds { get; set; }
    [JsonPropertyName("External_Urls")]
    public ExternalUrl[]? ExternalUrls { get; set; }
    public string? Href { get; set; }
    public string? Id { get; set; }
    [JsonPropertyName("Is_Playable")]
    public bool? IsPlayable { get; set; }
    // public Linked_From Linked_From { get; set; }
    public Restriction[]? Restrictions { get; set; }
    public string? Name { get; set; }
    public int? Popularity { get; set; }
    [JsonPropertyName("Preview_Url")]
    public string? PreviewUrl { get; set; }
    [JsonPropertyName("Track_Number")]
    public int? TrackNumber { get; set; }
    public string? Type { get; set; }
    public string? Uri { get; set; }
    [JsonPropertyName("Is_Local")]
    public bool? IsLocal { get; set; }
}
