namespace Pure.BO.Transport.PublicTransport.RealtimeTrains
{
    public sealed class Service
    {
        /// <summary>
        /// The <see cref="LocationDetail"/> for this.
        /// </summary>
        public LocationDetail? LocationDetail { get; set; }

        /// <summary>
        /// The service uid.
        /// </summary>
        /// <example>
        /// C58076
        /// </example>
        public string? ServiceUid { get; set; }

        /// <summary>
        /// The running date of this service, 
        /// based on its departure time from the first origin. In format YYYY-MM-DD.
        /// </summary>
        public string? RunDate { get; set; }

        /// <summary>
        /// The train identity that this service was planned to run to.
        /// FOC operated services will always show as FRGT.
        /// </summary>
        public string? TrainIdentity { get; set; }

        /// <summary>
        /// Identifies the current running identity of the service.
        /// </summary>
        public string? RunningIdentity { get; set; }

        /// <summary>
        /// The two character identifier, as used by ATOC, 
        /// to identify the service operator
        /// </summary>
        /// <example>
        /// SW
        /// </example>
        public string? AtocCode { get; set; }

        /// <summary>
        /// Service operator.
        /// </summary>
        /// <remarks>
        /// South West Trains.
        /// </remarks>
        public string? AtocName { get; set; }

        /// <summary>
        /// The service type.
        /// </summary>
        /// <remarks>
        /// Contains the type of service this is, bus, ship or train.
        /// </remarks>
        public string? ServiceType { get; set; }

        /// <summary>
        /// Determins whether the train is a passenger train or not.
        /// </summary>
        public bool? IsPassenger { get; set; }
    }
}
