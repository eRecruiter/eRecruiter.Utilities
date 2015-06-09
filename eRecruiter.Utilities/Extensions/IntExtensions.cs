using System;

namespace eRecruiter.Utilities
{
    public static class IntExtensions
    {
        public static bool IsInt(this string s)
        {
            return IsInt(s, false);
        }

        public static bool IsInt(this string s, bool emptyIsInt)
        {
            if (s.IsNullOrEmpty())
            {
                return emptyIsInt;
            }

            int i;
            s = s.Replace(",", "").Replace(".", ""); //we want to support pretty-printed ints like '1.500'
            return int.TryParse(s, out i);
        }

        public static int GetInt(this string s)
        {
            if (!s.IsInt())
            {
                throw new FormatException(string.Format("The string '{0}' is not an int.", s));
            }
            s = s.Replace(",", "").Replace(".", ""); //we want to support pretty-printed ints like '1.500'
            return int.Parse(s);
        }

        public static int GetInt(this string s, int defaultValue)
        {
            return s.IsInt() ? s.GetInt() : defaultValue;
        }

        public static int? GetIntOrNull(this string s)
        {
            if (s.IsInt())
            {
                return s.GetInt();
            }
            return null;
        }
    }
}
