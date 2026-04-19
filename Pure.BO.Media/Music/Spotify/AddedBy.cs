using System.Text.Json.Serialization;

namespace Pure.BO.Media.Music.Spotify;

public class AddedBy
{
    [JsonPropertyName("External_Urls")]
    public ExternalUrl[]? ExternalUrls { get; set; }
    public Follower[]? Followers { get; set; }
    public string? Href { get; set; }
    public string? Id { get; set; }
    public string? Type { get; set; }
    public string? Uri { get; set; }
}
