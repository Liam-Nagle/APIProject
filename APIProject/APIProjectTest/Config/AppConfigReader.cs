using System.Configuration;

namespace APIProjectTest
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string APIKey = ConfigurationManager.AppSettings["api_key"];
    }
}
