using Pure.BO.Transport.PublicTransport.Trains;

namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// The route
/// </summary>
public class Route
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.TimetableRoute, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// A <see cref="Stationinterval"/> collection.
    /// </summary>
    public Stationinterval[]? StationIntervals { get; set; }

    /// <summary>
    /// A <see cref="Schedule"/> collection.
    /// </summary>
    public Schedule[]? Schedules { get; set; }
}
