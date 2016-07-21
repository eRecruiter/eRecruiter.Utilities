﻿using System;
using System.Linq;

namespace eRecruiter.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the string cropped to a given max length when not empty otherwise returns an empty string.
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="maxLength">max length of string</param>
        /// <returns>cropped string</returns>
        public static string MaxLen(this string s, int maxLength)
        {
            return MaxLen(s, maxLength, null);
        }

        public static string MaxLen(this string s, int maxLength, string appendWhenShortened)
        {
            if (s.IsNullOrEmpty())
            {
                return "";
            }
            if (s.Length > maxLength)
            {
                return s.Substring(0, maxLength) + (appendWhenShortened.HasValue() ? appendWhenShortened : "");
            }
            return s;
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        [Obsolete("Use IsNullOrEmpty extension method.")]
        public static bool IsNoE(this string s)
        {
            return s.IsNullOrEmpty();
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        [Obsolete("Use IsNullOrWhiteSpace extension method.")]
        public static bool IsNoW(this string s)
        {
            return s.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// Returns true if string has value (means string neiter not null nor Empty).
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>Returns true if string has value</returns>
        public static bool HasValue(this string s)
        {
            return !s.IsNullOrEmpty();
        }

        /// <summary>
        /// Returns the string itself when not empty
        /// or an empty string if null or empty.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ValueOrEmpty(this string s)
        {
            return s.IsNullOrEmpty() ? string.Empty : s;
        }

        /// <summary>
        /// Returns the string itself when not empty or the defaultValue if null or empty.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string ValueOr(this string s, string defaultValue)
        {
            return s.IsNullOrEmpty() ? defaultValue : s;
        }

        /// <summary>
        /// Compare if two specified string objects have the same content (case insensitive)
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="t">string</param>
        /// <returns>Returns true if strings match, else false</returns>
        public static bool Is(this string s, string t)
        {
            if (t.IsNullOrEmpty() && s.IsNullOrEmpty())
            {
                return true;
            }
            return s.HasValue() && s.Equals(t, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool Is(this string s, params string[] t)
        {
            return t.Any(s.Is);
        }

        public static bool Is(this string s, bool b)
        {
            if (!s.IsBool())
            {
                return false;
            }
            return s.GetBool() == b;
        }

        public static bool Is(this string s, int i)
        {
            if (!s.IsInt())
            {
                return false;
            }
            return s.GetInt() == i;
        }

        public static string GetStringOrNull(this string s)
        {
            return s.HasValue() ? s : null;
        }

        public static string RemoveCrlf(this string s)
        {
            return !s.IsNullOrEmpty() ? s.Replace("\n", "").Replace("\r", "") : s;
        }
    }
}
