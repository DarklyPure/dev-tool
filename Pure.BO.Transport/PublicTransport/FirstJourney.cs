namespace Pure.BO.Transport.PublicTransport
{
    /// <summary>
    /// The first journey
    /// </summary>
    public class FirstJourney
    {
        /// <summary>
        /// The First Journey time.
        /// </summary>
        /// <example>
        /// Tfl.Api.Presentation.Entities.KnownJourney, Tfl.Api.Presentation.Entities
        /// </example>
        public string? Type { get; set; }

        /// <summary>
        /// The Hour.
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
}
