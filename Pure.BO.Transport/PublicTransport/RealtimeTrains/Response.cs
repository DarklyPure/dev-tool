namespace Pure.BO.Transport.PublicTransport.RealtimeTrains
{
    /// <summary>
    /// The Realtime Trains API response
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public sealed class Response
    {
        /// <summary>
        /// The location that was queried for.
        /// </summary>
        public Location? Location { get; init; }

        /// <summary>
        /// The filter.
        /// </summary>
        public object? Filter { get; init; }

        /// <summary>
        /// The collection of <see cref="Service"/> instances returned.
        /// </summary>
        public Service[]? Services { get; init; }
    }
}
