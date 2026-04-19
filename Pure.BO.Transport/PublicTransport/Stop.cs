using Pure.BO.Transport.PublicTransport.Trains;

namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// A stop.
/// </summary>
public class Stop
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.MatchedStop, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The parent Id.
    /// </summary>
    public string? ParentId { get; set; }

    /// <summary>
    /// The station Id.
    /// </summary>
    public string? StationId { get; set; }

    /// <summary>
    /// The IcsId.
    /// </summary>
    public string? IcsId { get; set; }

    /// <summary>
    /// Top most parent Id.
    /// </summary>
    public string? TopMostParentId { get; set; }

    /// <summary>
    /// A <see cref="Node"/> collection.
    /// </summary>
    public string[]? Modes { get; set; }

    /// <summary>
    /// The stop type.
    /// </summary>
    public string? StopType { get; set; }

    /// <summary>
    /// The zone.
    /// </summary>
    public string? Zone { get; set; }

    /// <summary>
    /// A <see cref="Line"/> collection.
    /// </summary>
    public Line[]? Lines { get; set; }

    /// <summary>
    /// The status.
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// The id.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The latitude.
    /// </summary>
    public float? Lat { get; set; }

    /// <summary>
    /// The longitude.
    /// </summary>
    public float? Lon { get; set; }

    /// <summary>
    /// Has disruption.
    /// </summary>
    public bool? HasDisruption { get; set; }
}
