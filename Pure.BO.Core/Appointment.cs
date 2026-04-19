namespace Pure.BO.Core
{
    public sealed class Appointment
    {
        #region Properties
        /// <summary>
        /// Switch specifying if the appointment is an all day appointment
        /// </summary>
        public bool AllDayEvent { get; set; }
        /// <summary>
        /// The body of the <see cref="Appointment"/>
        /// </summary>
        public string? Body { get; set; }
        private Dictionary<string, string>? _metaData;
        /// <summary>
        /// <see cref="Dictionary{TKey, TValue}"/> of MetaData
        /// </summary>
        public Dictionary<string, string> MetaData
        {
            get => _metaData ??= [];
            set => _metaData = value;
        }
        /// <summary>
        /// The duration in minutes of the <see cref="Appointment"/>
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// The end time of the <see cref="Appointment"/>
        /// </summary>
        public DateTime End { get; set; }
        /// <summary>
        /// Is the <see cref="Appointment"/> a recurring <see cref="Appointment"/>
        /// </summary>
        public bool IsRecurring { get; set; }
        /// <summary>
        /// The start time of the <see cref="Appointment"/>
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// The subject of the <see cref="Appointment"/>
        /// </summary>
        public string? Subject { get; set; }
        #endregion
    }
}
