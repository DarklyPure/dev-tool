namespace Pure.BO.Transport.PublicTransport;


/// <summary>
/// The Interval.
/// </summary>
public class Interval
{
    /// <summary>
    /// The Type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.Interval, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The stop id.
    /// </summary>
    public string? StopId { get; set; }

    /// <summary>
    /// The time to arrival
    /// </summary>
    /// <example>
    /// 5.0
    /// </example>
    public float? TimeToArrival { get; set; }
}
