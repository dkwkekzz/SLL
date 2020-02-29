using System;
using System.Collections.Generic;
using System.Configuration;

namespace SLL.Extensions
{
	public static class ConfigExtensions
    {
        public static bool ParseConfigOrDefault(this string appKey, bool defaultVal)
        {
            if (!bool.TryParse(ConfigurationManager.AppSettings[appKey], out bool val))
                return defaultVal;
            return val;
        }

        public static int ParseConfigOrDefault(this string appKey, int defaultVal)
        {
            if (!int.TryParse(ConfigurationManager.AppSettings[appKey], out int val))
                return defaultVal;
            return val;
        }

        public static int ParseConfig(this string appKey)
        {
            return int.Parse(ConfigurationManager.AppSettings[appKey]);
        }
    }
}
