namespace Pure.BO.Transport.PublicTransport;

/// <summary>
/// A schedule.
/// </summary>
public class Schedule
{
    /// <summary>
    /// The type.
    /// </summary>
    /// <example>
    /// Tfl.Api.Presentation.Entities.Schedule, Tfl.Api.Presentation.Entities
    /// </example>
    public string? Type { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    /// <example>
    /// Saturday (also Good Friday)
    /// </example>
    public string? Name { get; set; }

    /// <summary>
    /// A <see cref="KnownJourney"/> collection.
    /// </summary>
    public Knownjourney[]? KnownJourneys { get; set; }

    /// <summary>
    /// The <see cref="FirstJourney"/>.
    /// </summary>
    public FirstJourney? FirstJourney { get; set; }

    /// <summary>
    /// The <see cref="Lastjourney"/>.
    /// </summary>
    public Lastjourney? LastJourney { get; set; }

    /// <summary>
    /// A <see cref="Period"/> collection.
    /// </summary>
    public Period[]? Periods { get; set; }
}
