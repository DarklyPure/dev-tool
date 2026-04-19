using System.Text.Json.Serialization;

namespace Pure.BO.Transport.PublicTransport.Trains;

/// <summary>
/// The line.
/// </summary>
public class Line
{
    /// <summary>
    /// The line type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.Identifier, Tfl.Api.Presentation.Entities
    /// </example>
    [JsonPropertyName("$type")]
    public string? LineType { get; set; }

    /// <summary>
    /// The Id.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The uri.
    /// </summary>
    public string? Uri { get; set; }

    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Line
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The <see cref="Crowding"/>.
    /// </summary>
    public Crowding? Crowding { get; set; }

    /// <summary>
    /// The route type.
    /// </summary>
    public string? RouteType { get; set; }

    /// <summary>
    /// The status.
    /// </summary>
    public string? Status { get; set; }
}
