namespace Pure.BO.Transport.PublicTransport
{
    /// <summary>
    /// The Frequency
    /// </summary>
    public class Frequency
    {
        /// <summary>
        /// The type of the Frequency.
        /// </summary>
        /// <example>
        /// Tfl.Api.Presentation.Entities.ServiceFrequency, Tfl.Api.Presentation.Entities
        /// </example>
        public string? Type { get; set; }

        /// <summary>
        /// The lowest frequency.
        /// </summary>
        /// <example>
        /// 10.0
        /// </example>
        public float? LowestFrequency { get; set; }

        /// <summary>
        /// The highest frequency.
        /// </summary>
        /// <example>
        /// 10.0
        /// </example>
        public float? HighestFrequency { get; set; }
    }
}
