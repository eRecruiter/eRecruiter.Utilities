using System;
using System.Linq;

namespace eRecruiter.Utilities
{
    public static class StringExtensions
    {
        public static string MaxLen(this string s, int maxLength)
        {
            return MaxLen(s, maxLength, null);
        }

        public static string MaxLen(this string s, int maxLength, string appendWhenShortened)
        {
            if (s.IsNoE())
                return "";
            if (s.Length > maxLength)
                return s.Substring(0, maxLength) + (appendWhenShortened.HasValue() ? appendWhenShortened : "");
            return s;
        }

        public static bool IsNoE(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNoW(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool HasValue(this string s)
        {
            return !s.IsNoE();
        }

        /// <summary>
        /// Returns the string itself when not empty
        /// or an empty string if null or empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ValueOrEmpty(this string s)
        {
            return s.IsNoE() ? string.Empty : s;
        }

        /// <summary>
        /// Returns the string itself when not empty
        /// or the defaultValue if null or empty.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ValueOr(this string s, string defaultValue)
        {
            return s.IsNoE() ? defaultValue : s;
        }

        public static bool Is(this string s, string t)
        {
            if (t.IsNoE() && s.IsNoE())
                return true;
            if (s.HasValue() && s.Equals(t, StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }

        public static bool Is(this string s, params string[] t)
        {
            return t.Any(s.Is);
        }

        public static bool Is(this string s, bool b)
        {
            if (!s.IsBool())
                return false;
            return s.GetBool() == b;
        }

        public static bool Is(this string s, int i)
        {
            if (!s.IsInt())
                return false;
            return s.GetInt() == i;
        }

        public static string GetStringOrNull(this string s)
        {
            if (s.HasValue())
                return s;
            return null;
        }

        public static string RemoveCrlf(this string s)
        {
            return !s.IsNoE() ? s.Replace("\n", "").Replace("\r", "") : s;
        }
    }
}
