using System;

namespace eRecruiter.Utilities
{
    public static class BoolExtensions
    {
        public static bool IsBool(this string s)
        {
            return IsBool(s, false);
        }

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

        public static bool GetBool(this string s)
        {
            if (!s.IsBool())
            {
                throw new FormatException(string.Format("The string '{0}' is not a bool.", s));
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

        public static bool GetBool(this string s, bool defaultValue)
        {
            return s.IsBool() ? s.GetBool() : defaultValue;
        }

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
