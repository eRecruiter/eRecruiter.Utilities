using System;

namespace eRecruiter.Utilities
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Check if a specified string represents a bool value
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <returns>Returns <value>true</value> if strings represents a bool value, else <value>false</value>.</returns>
        public static bool IsBool(this string s)
        {
            return IsBool(s, false);
        }

        /// <summary>
        /// Check if a specified string represents a bool value 
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <param name="emptyIsBool">indicates if an empty value represents a bool value or not</param>
        /// <returns>Returns <value>true</value> if strings represents a bool value, else <value>false</value>.</returns>
        public static bool IsBool(this string s, bool emptyIsBool)
        {
            if (emptyIsBool && s.IsNullOrEmpty())
            {
                return true;
            }

            //special handling for the MCV checkbox
            if (s.Is("true,false") || s.Is("false,false"))
            {
                return true;
            }

            bool b;
            return bool.TryParse((s ?? "").ToLower(), out b);
        }

        /// <summary>
        /// Parse bool value from string
        /// </summary>
        /// <param name="s">string representation of a bool</param>
        /// <returns>Returns the converted bool value</returns>
        /// <exception cref="FormatException">If string is not a bool value. </exception>
        public static bool GetBool(this string s)
        {
            if (!s.IsBool())
            {
                throw new FormatException($"The string '{s}' is not a bool.");
            }
            //special handling for the MVC checkbox
            if (s.Is("true,false"))
            {
                return true;
            }
            if (s.Is("false,false"))
            {
                return false;
            }
            return bool.Parse(s.ToLower());
        }

        /// <summary>
        /// Parse bool value from string or return given default value if string is no bool value.
        /// </summary>
        /// <param name="s">string representation of a bool</param>
        /// <param name="defaultValue">default bool value</param>
        /// <returns>Returns the converted bool value or default value if conversion fails.</returns>
        public static bool GetBool(this string s, bool defaultValue)
        {
            return s.IsBool() ? s.GetBool() : defaultValue;
        }

        /// <summary>
        /// Parse bool value from string or return null if conversion fails.
        /// </summary>
        /// <param name="s">string representation of a bool</param>
        /// <returns>Returns the converted bool value or null if conversion fails.</returns>
        public static bool? GetBoolOrNull(this string s)
        {
            if (s.IsBool())
            {
                return s.GetBool();
            }
            return null;
        }
    }
}
