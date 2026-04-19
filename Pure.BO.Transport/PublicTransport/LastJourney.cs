namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// The last journey.
/// </summary>
public class Lastjourney
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.KnownJourney, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The hour.
    /// </summary>
    public string? Hour { get; set; }

    /// <summary>
    /// The minute.
    /// </summary>
    public string? Minute { get; set; }

    /// <summary>
    /// The interval Id.
    /// </summary>
    public int? IntervalId { get; set; }
}
