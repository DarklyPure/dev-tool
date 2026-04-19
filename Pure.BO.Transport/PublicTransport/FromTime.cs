namespace Pure.BO.Transport.PublicTransport
{
    /// <summary>
    /// The from time
    /// </summary>
    public class FromTime
    {
        /// <summary>
        /// The type.
        /// </summary>
        /// <example>
        /// Tfl.Api.Presentation.Entities.TwentyFourHourClockTime, Tfl.Api.Presentation.Entities
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
    }
}
