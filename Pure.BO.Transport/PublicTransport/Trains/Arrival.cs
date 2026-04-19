namespace Pure.BO.Transport.PublicTransport.Trains;

/// <summary>
/// Arrival details.
/// </summary>
public class Arrival
{
    /// <summary>
    /// tHE ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The Operation type
    /// </summary>
    public int? OperationType { get; set; }

    /// <summary>
    /// The vehicle Id.
    /// </summary>
    public string? VehicleId { get; set; }

    /// <summary>
    /// The Naptan Id.
    /// </summary>
    public string? NaptanId { get; set; }

    /// <summary>
    /// The station name.
    /// </summary>
    public string? StationName { get; set; }

    /// <summary>
    /// The Line Id.
    /// </summary>
    public string? LineId { get; set; }

    /// <summary>
    /// The line name
    /// </summary>
    public string? LineName { get; set; }

    /// <summary>
    /// The platform name.
    /// </summary>
    public string? PlatformName { get; set; }

    /// <summary>
    /// The direction.
    /// </summary>
    public string? Direction { get; set; }

    /// <summary>
    /// The bearing.
    /// </summary>
    public string? Bearing { get; set; }

    /// <summary>
    /// The destination Naptan Id.
    /// </summary>
    public string? destinationNaptanId { get; set; }

    /// <summary>
    /// The destination name.
    /// </summary>
    public string? DestinationName { get; set; }

    /// <summary>
    /// The timestamp.
    /// </summary>
    public string? Timestamp { get; set; }

    /// <summary>
    /// The time to arrival at the stationo.
    /// </summary>
    public int? TimeToStation { get; set; }

    /// <summary>
    /// The current location.
    /// </summary>
    public string? currentLocation { get; set; }

    /// <summary>
    /// The towards data.
    /// </summary>
    public string? Towards { get; set; }

    /// <summary>
    /// The expected arrival.
    /// </summary>
    public string? ExpectedArrival { get; set; }

    /// <summary>
    /// The time to live.
    /// </summary>
    public string? TimeToLive { get; set; }

    /// <summary>
    /// The mode name.
    /// </summary>
    public string? ModeName { get; set; }

    /// <summary>
    /// The timing.
    /// </summary>
    // public Timing? Timing { get; set; }
}
