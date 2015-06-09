using System;
using System.Globalization;

namespace eRecruiter.Utilities
{
    public static class DateTimeExtensions
    {
        public static bool IsDate(this string s)
        {
            return IsDate(s, false);
        }

        public static bool IsDate(this string s, bool emptyIsDate)
        {
            if (emptyIsDate && s.IsNullOrEmpty())
            {
                return true;
            }
            DateTime d;
            var result = DateTime.TryParse(s, out d);
            return result || DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);
        }

        public static DateTime GetDate(this string s)
        {
            if (!s.IsDate())
            {
                throw new FormatException("The string '" + s + "' is not a date.");
            }
            try
            {
                return DateTime.Parse(s);
            }
            catch
            {
                return DateTime.Parse(s, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
        }

        public static DateTime GetDate(this string s, DateTime defaultValue)
        {
            return s.IsDate() ? s.GetDate() : defaultValue;
        }

        /// <summary>
        /// This methods converts a string to a DateTime if possible, otherwise it returns null
        /// </summary>
        /// <param name="s">date to be converted</param>
        /// <returns>DateTime if possible to convert, otherwise null</returns>
        public static DateTime? GetDateOrNull(this string s)
        {
            if (s.IsDate())
            {
                return s.GetDate();
            }
            return null;
        }

        public static DateTime FirstDayOfMonthFromDateTime(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime LastDayOfMonthFromDateTime(this DateTime dateTime)
        {
            return FirstDayOfMonthFromDateTime(dateTime).AddMonths(1).AddDays(-1);
        }
    }
}
