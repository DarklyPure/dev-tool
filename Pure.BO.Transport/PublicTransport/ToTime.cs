namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// The to time
/// </summary>
public class Totime
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <remarks>
    /// Tfl.Api.Presentation.Entities.TwentyFourHourClockTime, Tfl.Api.Presentation.Entities
    /// </remarks>
    public string? Type { get; set; }

    /// <summary>
    /// The hour.
    /// </summary>
    public string? Hour { get; set; }

    /// <summary>
    /// The minute.
    /// </summary>
    public string? Minute { get; set; }
}
