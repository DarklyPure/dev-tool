namespace Pure.BO.Transport.PublicTransport.RealtimeTrains
{
    /// <summary>
    /// The location (station).
    /// </summary>
    public sealed class Location
    {
        /// <summary>
        /// The name of the <see cref="Location"/>.
        /// </summary>
        /// <example>
        /// Harrow-on-the-Hill
        /// </example>
        public string? Name { get; set; }

        /// <summary>
        /// The CRS code for the <see cref="Location"/>.
        /// </summary>
        /// <example>
        /// HOH
        /// </example>
        public string? Crs { get; set; }

        /// <summary>
        /// The TIPLOC code for the <see cref="Location"/>.
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
        /// The country for the <see cref="Location"/>.
        /// </summary>
        /// <example>
        /// gb
        /// </example>
        public string? Country { get; set; }

        /// <summary>
        /// The system.
        /// </summary>
        /// <example>
        /// nr
        /// </example>
        public string? System { get; set; }
    }
}
