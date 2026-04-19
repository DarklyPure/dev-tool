namespace Pure.BO.Transport.PublicTransport.RealtimeTrains
{
    public sealed class LocationDetail
    {
        /// <summary>
        /// Details if this <see cref="LocationDetail"/> has been activated
        /// for realtime information.
        /// </summary>
        public bool? RealtimeActivated { get; set; }

        /// <summary>
        /// The TIPLOC code for the <see cref="LocationDetail"/>.
        /// </summary>
        /// <example>
        /// HAROOTH, AYLSPWY
        /// </example>
        /// <remarks>
        /// HAROOTH = Harrow on the hill
        /// AYLSPWY = Aylesbury Parkway
        /// </remarks>
        public string? Tiploc { get; set; }

        /// <summary>
        /// The CRS code for the <see cref="Location"/>.
        /// </summary>
        /// <example>
        /// HOH
        /// </example>
        public string? Crs { get; set; }

        /// <summary>
        /// The <see cref="LocationDetail"/> description.
        /// </summary>
        /// <example>
        /// Harrow-on-the-Hill
        /// </example>
        public string? Description { get; set; }

        /// <summary>
        /// Public Timetable arrival time of the service at this location, 
        /// in format HHmm
        /// </summary>
        /// <example>
        /// 2139
        /// </example>
        public string? GbttBookedArrival { get; set; }

        /// <summary>
        /// Public Timetable departure time of the service at this location, 
        /// in format HHmm
        /// </summary>
        /// <example>
        /// 2139
        /// </example>
        public string? GbttBookedDeparture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Origin[]? Origin { get; set; }

        /// <summary>
        /// A collection of <see cref="Destination"/> instances.
        /// </summary>
        public Destination[]? Destination { get; set; }

        /// <summary>
        /// Whether this service calls at this location.
        /// </summary>
        /// <remarks>
        /// This is set as true even if the service ends up non-stopping this station for whatever reason.
        /// </remarks>
        public bool IsCall { get; set; }

        /// <summary>
        /// Whether this service makes a public call at this location.
        /// </summary>
        /// <remarks>
        /// This is set as true even if the service ends up non-stopping this station for whatever reason.
        /// </remarks>
        public bool? IsPublicCall { get; set; }

        /// <summary>
        /// Expected or actual arrival time at this <see cref="LocationDetail"/>, 
        /// in format HHmm.
        /// </summary>
        public string? RealtimeArrival { get; set; }

        /// <summary>
        /// Whether this is an actual or expected time.
        /// </summary>
        /// <remarks>
        /// Always appears if realtimeArrival is also present.
        /// If true, actual - if false, expected.
        /// </remarks>
        public bool? RealtimeArrivalActual { get; set; }

        /// <summary>
        /// Expected or actual departure time of this service,
        /// in format HHmm
        /// </summary>
        public string? RealtimeDeparture { get; set; }

        /// <summary>
        /// Whether this is an actual or expected time.
        /// </summary>
        /// <remarks>
        /// If true, actual - if false, expected.
        /// </remarks>
        public bool? RealtimeDepartureActual { get; set; }

        /// <summary>
        /// Represents the original origin & destination of a service. 
        /// </summary>
        /// <example>
        /// CALL, PASS, ORIGIN, 
        /// DESTINATION, STARTS, TERMINATES, 
        /// CANCELLED_CALL, CANCELLED_PASS. 
        /// ORIGIN and DESTINATION 
        /// </example>
        /// <remarks>
        /// If STARTS or TERMINATES appear, then this means a service has started short or 
        /// terminated en-route - the original origin/destination will show CANCELLED_CALL.
        /// </remarks>
        public string? DisplayAs { get; set; }

        /// <summary>
        /// Public Timetable arrival time of the service at this location, in format HHmm
        /// </summary>
        public bool? GbttBookedArrivalNextDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? GbttBookedDepartureNextDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? RealtimeArrivalNextDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? RealtimeDepartureNextDay { get; set; }
    }
}
