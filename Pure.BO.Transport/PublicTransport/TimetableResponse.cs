using Pure.BO.Transport.PublicTransport.Trains;

namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// A Timetable response
/// </summary>
public class TimetableResponse
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.TimetableResponse, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The line Id.
    /// </summary>
    public string? LineId { get; set; }

    /// <summary>
    /// The line name.
    /// </summary>
    public string? LineName { get; set; }

    /// <summary>
    /// The direction
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// A <see cref="Station"/> collection.
    /// </summary>
    public Station[]? Stations { get; set; }

    /// <summary>
    /// A <see cref="Stop"/> collection.
    /// </summary>
    public Stop[]? Stops { get; set; }

    /// <summary>
    /// The <see cref="Timetable"/>
    /// </summary>
    public Timetable? Timetable { get; set; }
}
