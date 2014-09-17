using System;
using System.Globalization;

namespace eRecruiter.Utilities
{
    public static class XmlUtility
    {
        public static string EnsureValidTagName(string s)
        {
            if (s.IsNoE())
                throw new ArgumentException("A valid XML tag-name must not be empty.");

            s = s[0].ToString(CultureInfo.CurrentCulture).ToLower() + s.Substring(1);

            s = s.Replace("\n", "").Replace("\r", "");
            s = s.Replace(" ", "_").Replace("-", "_").Replace("\"", "").Replace("'", "");

            s = s.Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue").Replace("ß", "ss");
            s = s.Replace("Ä", "Ae").Replace("Ö", "Oe").Replace("Ü", "Ue");

            if (s[0].ToString(CultureInfo.CurrentCulture).IsInt())
                s = "_" + s;

            return s;
        }
    }
}
