namespace Pure.BO.Core
{
    public sealed class CalendarItem
    {
        #region Constructors
        public CalendarItem() => DateStart = DateTime.Now;
        public CalendarItem(DateTime dateStart) : this() => DateStart = dateStart;
        public CalendarItem(DateTime dateStart, DateTime dateEnd) : this(dateStart) => DateEnd = dateEnd;
        #endregion

        #region Properties
        /// <summary>
        /// The start date for the calendar
        /// </summary>
        public DateTime DateStart { get; set; }
        /// <summary>
        /// The end date for the calendar
        /// </summary>
        public DateTime? DateEnd { get; set; }
        /// <summary>
        /// Switch specifying if the <see cref="CalendarItem"/> is an all day occurrence
        /// </summary>
        public bool IsAllDay { get; set; }
        /// <summary>
        /// The title of the <see cref="CalendarItem"/>
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// A description of the <see cref="CalendarItem"/>
        /// </summary>
        public string? Description { get; set; }
        #endregion

        #region Helpers
        public void MakeAllDay()
        {
            IsAllDay = true;
            // Set for the start of the current date
            DateStart = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day, 0, 0, 0);
            // Set for the end of the current date
            DateEnd = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day, 23, 59, 59);
        }
        #endregion
    }
}
