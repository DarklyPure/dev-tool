using System.Text.Json.Serialization;

namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// The period.
/// </summary>
public class Period
{
    /// <summary>
    /// The period type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.Period, Tfl.Api.Presentation.Entities.
    /// </example>
    [JsonPropertyName("$type")]
    public string? PeriodType { get; set; }

    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Normal
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The from time.
    /// </summary>
    // public Fromtime? FromTime { get; set; }

    /// <summary>
    /// The to time.
    /// </summary>
    public Totime? ToTime { get; set; }

    /// <summary>
    /// The frequency.
    /// </summary>
    public Frequency? Frequency { get; set; }
}
