namespace Pure.BO.Transport.PublicTransport.Trains;

/// <summary>
/// The station interval
/// </summary>
public class Stationinterval
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.StationInterval, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The id.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// An <see cref="Interval"/> collection.
    /// </summary>
    public Interval[]? Intervals { get; set; }
}
