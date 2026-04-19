using System.Text.Json.Serialization;

namespace Pure.BO.Media.Music.Spotify;

public class Item
{
    [JsonPropertyName("Added_At")]
    public string? AddedAt { get; set; }

    [JsonPropertyName("Added_By")]
    public AddedBy? AddedBy { get; set; }

    [JsonPropertyName("Is_Local")]
    public bool? IsLocal { get; set; }

    public Track? Track { get; set; }
}
