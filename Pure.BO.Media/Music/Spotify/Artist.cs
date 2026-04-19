using System.Text.Json.Serialization;

namespace Pure.BO.Media.Music.Spotify;

public class Artist
{
    [JsonPropertyName("External_Urls")]
    public ExternalUrl[]? External_Urls { get; set; }

    public string? Href { get; set; }

    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Uri { get; set; }
}
