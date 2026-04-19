namespace Pure.BO.Core
{
    public sealed class Address : Core
    {
        #region Properties
        /// <summary>
        /// The number of the house
        /// </summary>
        public string? HouseNumber { get; set; }
        /// <summary>
        /// The number of the flat
        /// </summary>
        public string? FlatNumber { get; set; }
        /// <summary>
        /// The name of the building
        /// </summary>
        public string? BuildingName { get; set; }
        /// <summary>
        /// The first line of the street address
        /// </summary>
        public string? Street1 { get; set; }
        /// <summary>
        /// The second line of the street address
        /// </summary>
        public string? Street2 { get; set; }
        /// <summary>
        /// The area of the address
        /// </summary>
        public string? Area { get; set; }
        /// <summary>
        /// The town
        /// </summary>
        public string? Town { get; set; }
        /// <summary>
        /// The region
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// The country
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// The postcode
        /// </summary>
        public string? Postcode { get; set; }
        #endregion

        #region Helpers
        #endregion
    }
}
