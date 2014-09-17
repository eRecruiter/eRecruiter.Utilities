using System;
using System.Text.RegularExpressions;

namespace eRecruiter.Utilities
{
    public static class HtmlUtility
    {
        private const string BreakRegex = "<br[ /]*?>";
        private const string Break = "<br />";

        public static string ConvertCrlfToBreaks(string s)
        {
            if (s.IsNoE())
                return "";
            s = s.Replace("\n", Break);
            s = s.Replace("\r", "");
            return s;
        }

        public static string ConvertBreaksToCrlf(string s)
        {
            if (s.IsNoE())
                return "";
            s = Regex.Replace(s, BreakRegex, Environment.NewLine, RegexOptions.IgnoreCase);
            return s;
        }

        public static string ConvertHtmlToText(string s)
        {
            if (s.IsNoE())
                return "";

            s = s.Replace("&nbsp;", " ").Replace((char)160, ' '); //both non breaking spaces
            s = s.Replace("\t", ""); //remove all tabs
            s = ConvertBreaksToCrlf(s);

            s = System.Net.WebUtility.HtmlDecode(s); //replace all HTML codes like &auml; with their proper character

            s = Regex.Replace(s, @"</p>\s*?<p>", Environment.NewLine, RegexOptions.Singleline | RegexOptions.IgnoreCase); //remove paragraphs
            s = Regex.Replace(s, @"<p>", Environment.NewLine, RegexOptions.Singleline | RegexOptions.IgnoreCase); //remove paragraphs
            s = Regex.Replace(s, @"</p>", Environment.NewLine, RegexOptions.Singleline | RegexOptions.IgnoreCase); //remove paragraphs
            s = Regex.Replace(s, @"<(.|\n)*?>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase); //remove tags
            s = Regex.Replace(s, @"/\*.*?\*/", "", RegexOptions.Singleline | RegexOptions.IgnoreCase); //remove html comments

            s = s.Trim();

            return s;
        }
    }
}
