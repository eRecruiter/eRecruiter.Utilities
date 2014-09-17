using System;

namespace eRecruiter.Utilities
{
    public static class IntExtensionMethods
    {
        public static bool IsInt(this string s)
        {
            return IsInt(s, false);
        }

        public static bool IsInt(this string s, bool emptyIsInt)
        {
            if (s.IsNoE())
                return emptyIsInt;

            int i;
            s = s.Replace(",", "").Replace(".", ""); //we want to support pretty-printed ints like '1.500'
            return int.TryParse(s, out i);
        }

        public static int GetInt(this string s)
        {
            if (s.IsInt())
            {
                s = s.Replace(",", "").Replace(".", ""); //we want to support pretty-printed ints like '1.500'
                return int.Parse(s);
            }
            throw new FormatException("The string '" + s + "' is not an int.");
        }

        public static int GetInt(this string s, int defaultValue)
        {
            if (s.IsInt())
                return s.GetInt();
            return defaultValue;
        }

        public static int? GetIntOrNull(this string s)
        {
            if (s.IsInt())
                return s.GetInt();
            return null;
        }
    }
}
