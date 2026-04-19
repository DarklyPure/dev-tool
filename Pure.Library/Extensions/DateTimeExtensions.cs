namespace Pure.Library.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GenerateRandomDateTime(this DateTime value, DateTime? minimumDateTime = null, DateTime? maximumDateTime = null)
        {
            Random random = new();

            minimumDateTime = minimumDateTime == null ? DateTime.MinValue : minimumDateTime;
            maximumDateTime = maximumDateTime == null ? DateTime.MaxValue : maximumDateTime;

            int year = random.Next(minimumDateTime.Value.Year, maximumDateTime.Value.Year);
            int month = random.Next(1, 12);

            int day = 0;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 11:
                case 12:

                    day = random.Next(1, 31);

                    break;
                case 2:

                    if (year.IsALeapYear())
                    {
                        day = random.Next(1, 29);
                    }
                    else
                    {
                        day = random.Next(1, 28);
                    }

                    break;
                case 4:
                case 6:
                case 9:

                    day = random.Next(1, 30);

                    break;
            }

            return new DateTime(year, month, day);
        }

        public static DateTimeOffset GenerateRandomDateTimeOffset(this DateTimeOffset value, DateTime? minimumDateTime = null, DateTime? maximumDateTime = null)
        {
            Random random = new();

            minimumDateTime = minimumDateTime == null ? DateTime.MinValue : minimumDateTime;
            maximumDateTime = maximumDateTime == null ? DateTime.MaxValue : maximumDateTime;

            int year = random.Next(minimumDateTime.Value.Year, maximumDateTime.Value.Year);
            int month = random.Next(1, 12);

            int day = 0;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 11:
                case 12:

                    day = random.Next(1, 31);

                    break;
                case 2:

                    if (year.IsALeapYear())
                    {
                        day = random.Next(1, 29);
                    }
                    else
                    {
                        day = random.Next(1, 28);
                    }

                    break;
                case 4:
                case 6:
                case 9:

                    day = random.Next(1, 30);

                    break;
            }

            return new DateTimeOffset(new DateTime(year, month, day));
        }

        /// <summary>
        /// Specifies if the year is a leap year
        /// </summary>
        /// <param name="value">The date in question</param>
        /// <returns>True if is a leap year</returns>
        public static bool IsALeapYear(this int value)
        {
            if (value % 4 == 0)
            {
                if (value % 100 == 0)
                {
                    if (value % 400 == 0)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
