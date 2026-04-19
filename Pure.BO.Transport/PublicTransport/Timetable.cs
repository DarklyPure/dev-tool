namespace Pure.BO.Transport.PublicTransport;

public class Timetable
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.Timetable, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The departure stop Id.
    /// </summary>
    public string? DepartureStopId { get; set; }

    /// <summary>
    /// A <see cref="Route"/> collection.
    /// </summary>
    public Route[]? Routes { get; set; }
}
