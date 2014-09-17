using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace eRecruiter.Utilities
{
    public static class DecimalExtensionMethods
    {
        public static bool IsDecimal(this string s)
        {
            return IsDecimal(s, CultureInfo.CurrentCulture);
        }

        public static bool IsDecimal(this string s, CultureInfo culture)
        {
            if (s.IsNoE())
                return false;
            decimal d;
            return decimal.TryParse(s, NumberStyles.Any, culture, out d);
        }

        public static bool IsDecimalCultureInvariant(this string s)
        {
            if (s.IsNoE())
                return false;
            decimal d;
            return decimal.TryParse(GetCultureFixedDecimal(s), NumberStyles.Any, CultureInfo.InvariantCulture, out d);
        }

        public static decimal GetDecimal(this string s)
        {
            return GetDecimal(s, CultureInfo.CurrentCulture);
        }

        public static decimal GetDecimal(this string s, CultureInfo culture)
        {
            if (s.IsDecimal(culture))
                return decimal.Parse(s, NumberStyles.Any, culture);
            throw new ArgumentException("The string '" + s.ToString(culture) + "' is not a decimal.");
        }

        public static decimal GetDecimalCultureInvariant(this string s)
        {
            if (s.IsDecimalCultureInvariant())
                return decimal.Parse(GetCultureFixedDecimal(s), NumberStyles.Any, CultureInfo.InvariantCulture);
            throw new ArgumentException("The string '" + s.ToString(CultureInfo.InvariantCulture) + "' is not a decimal.");
        }

        public static decimal GetDecimal(this string s, decimal defaultValue)
        {
            if (s.IsDecimal())
                return s.GetDecimal();
            return defaultValue;
        }

        public static decimal? GetDecimalOrNull(this string s)
        {
            if (s.IsDecimal())
                return s.GetDecimal();
            return null;
        }

        /// <summary>
        /// This method fixes confusion for different decimal representations, for example '1.500,20' vs. '1,500.20'.
        /// It simply removes all the separators and only leaves the comma.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string GetCultureFixedDecimal(string s)
        {
            if (s.HasValue())
            {
                var pointIndex = s.IndexOf('.');
                var commaIndex = s.IndexOf(',');

                var containedBothSeparators = false;

                //replace 1.500,20 with 1500,20
                if (pointIndex >= 0 && commaIndex > pointIndex)
                {
                    s = s.Replace(".", "");
                    containedBothSeparators = true;
                }
                else if (commaIndex >= 0 && pointIndex > commaIndex)
                {
                    //replace 1,500.20 with 1500.20           
                    s = s.Replace(",", "");
                    containedBothSeparators = true;
                }

                s = s.Replace(",", "."); //we only support invariant culture decimals

                //we want to remove all thousand-separators
                //but only if all separators are in 3er-steps and are above a certain length
                if (!containedBothSeparators && s.Length >= 5)
                {
                    if (Regex.IsMatch(s, @"^\-?\d{1,3}(\.\d\d\d)+$"))
                        s = s.Replace(".", "");
                }

            }
            return s;
        }
    }
}
