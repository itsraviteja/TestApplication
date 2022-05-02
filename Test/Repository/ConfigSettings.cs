using Microsoft.Extensions.Configuration;

namespace Test.Repository
{
    public class ConfigSettings
    {
        private const string _connectionString = "ConnectionString";

        public static string ConfigConnectionString(IConfiguration _config) { return GetConnectionConfigValue(_config, _connectionString, false); }
        private static string GetConnectionConfigValue(IConfiguration _config, string key, bool decrypt)
        {
            if (key.Trim().Length == 0)
            {
                return "";
            }

            string value = string.Empty;

            if (decrypt)
            {
                value = _config.GetConnectionString(key);
                if (value.Trim().Length == 0)
                {
                    return "";
                }

                return value;
            }
            else
            {
                return value = _config.GetConnectionString(key);
            }
        }

    }
}
