namespace Pure.BO.Transport.PublicTransport.RealtimeTrains
{
    /// <summary>
    /// The train destination. Part of <see cref=""/>
    /// </summary>
    public sealed class Destination
    {
        /// <summary>
        /// The TIPLOC code for the <see cref="Destination"/>.
        /// </summary>
        /// <example>
        /// HAROOTH, AYLSPWY
        /// </example>
        /// <remarks>
        /// HAROOTH = Harrow on the hill
        /// AYLSPWY = Aylesbury Parkway
        /// </remarks>
        public string? Tiploc { get; init; }

        /// <summary>
        /// The description of the <see cref="Destination"/>.
        /// </summary>
        /// <example>
        /// Harrow on the hill.
        /// </example>
        public string? Description { get; init; }

        /// <summary>
        /// The working time for this <see cref="Destination"/>, I.e. arrival time.
        /// </summary>
        /// <example>
        /// 212700
        /// </example>
        /// <remarks>
        /// Formatted in HHmmss.
        /// </remarks>
        public string? WorkingTime { get; init; }

        /// <summary>
        /// The public (published) time for this <see cref="Destination"/>, I.e. arrival time.
        /// </summary>
        /// <example>
        /// 2127
        /// </example>
        /// <remarks>
        /// Note. This what is published, and may differ from the
        /// <see cref="WorkingTime"/> which is the real, actual time.
        /// </remarks>
        public string? PublicTime { get; init; }
    }
}
