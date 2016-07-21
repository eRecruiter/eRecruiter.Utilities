using System;

namespace eRecruiter.Utilities
{
    public static class IntExtensions
    {
        /// <summary>
        /// Check if string represents an integer
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <returns>Returns <value>true</value> if string is an integer</returns>
        public static bool IsInt(this string s)
        {
            return IsInt(s, false);
        }

        /// <summary>
        /// Check if string representation of a number is null, empty or an integer
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <param name="emptyIsInt">return value if if string is null or empty</param>
        /// <returns>Returns true if string is an integer or <see cref="emptyIsInt"/> if string is null or empty</returns>
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

        /// <summary>
        /// Converts the string representation of a number to its integer equivalent.
        /// </summary>
        /// <param name="s">string representation of a number</param>
        /// <returns>Returns the converted integer value</returns>
        /// <exception cref="FormatException">If string is not an integer. </exception>
        public static int GetInt(this string s)
        {
            if (!s.IsInt())
            {
                throw new FormatException($"The string '{s}' is not an int.");
            }
            s = s.Replace(",", "").Replace(".", ""); //we want to support pretty-printed ints like '1.500'
            return int.Parse(s);
        }

        /// <summary>
        /// Convert a string to it's integer equivalent if possible, otherwise the given default value is returned.
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="defaultValue">return value if if string is null or empty</param>
        /// <returns>Returns given <see cref="defaultValue"/> if string is no int, otherwise returns the integer equivalent.</returns>
        public static int GetInt(this string s, int defaultValue)
        {
            return s.IsInt() ? s.GetInt() : defaultValue;
        }

        /// <summary>
        /// Convert a string to it's integer equivalent if possible, otherwise it returns null
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>Returns null if conversion fail, otherwise returns the integer equivalent.</returns>
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
