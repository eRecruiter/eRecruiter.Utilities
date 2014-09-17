using System;

namespace eRecruiter.Utilities
{
    public static class BoolExtensionMethods
    {
        public static bool IsBool(this string s)
        {
            return IsBool(s, false);
        }

        public static bool IsBool(this string s, bool emptyIsBool)
        {
            if (emptyIsBool && s.IsNoE())
                return true;

            //special handling for the MCV checkbox
            if (s.Is("true,false") || s.Is("false,false"))
                return true;

            bool b;
            return bool.TryParse((s ?? "").ToLower(), out b);
        }

        public static bool GetBool(this string s)
        {
            if (s.IsBool())
            {
                //special handling for the MVC checkbox
                if (s.Is("true,false"))
                    return true;
                if (s.Is("false,false"))
                    return false;
                return bool.Parse(s.ToLower());
            }
            throw new FormatException("The string '" + s + "' is not a bool.");
        }

        public static bool GetBool(this string s, bool defaultValue)
        {
            if (s.IsBool())
                return s.GetBool();
            return defaultValue;
        }

        public static bool? GetBoolOrNull(this string s)
        {
            if (s.IsBool())
                return s.GetBool();
            return null;
        }
    }
}
