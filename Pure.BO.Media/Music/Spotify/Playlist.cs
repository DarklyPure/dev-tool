using System.Text.Json.Serialization;

namespace Pure.BO.Media.Music.Spotify;

public sealed class Playlist
{
    public bool? Collaborative { get; set; }
    public string? Description { get; set; }
    [JsonPropertyName("External_Urls")]
    public ExternalUrl[]? ExternalUrls { get; set; }
    public Follower[]? Followers { get; set; }
    public string? Href { get; set; }
    public string? Id { get; set; }
    public Image[]? Images { get; set; }
    public string? Name { get; set; }
    public Owner? Owner { get; set; }
    [JsonPropertyName("Public")]
    public bool? IsPublic { get; set; }
    [JsonPropertyName("Snapshot_id")]
    public string? SnapshotId { get; set; }
    public Tracks? Tracks { get; set; }
    public string? Type { get; set; }
    public string? Uri { get; set; }
}
