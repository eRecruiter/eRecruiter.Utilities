using System.Configuration;

namespace eRecruiter.Utilities
{
    public static class Settings
    {
        public static bool Get(string key, bool defaultValue)
        {
            return Get(key, "").GetBool(defaultValue);
        }

        public static int Get(string key, int defaultValue)
        {
            return Get(key, "").GetInt(defaultValue);
        }

        public static string Get(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key].IsNullOrEmpty() ? defaultValue : ConfigurationManager.AppSettings[key];
        }
    }
}
