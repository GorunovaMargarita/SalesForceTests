using Microsoft.Extensions.Configuration;


namespace Core.Configuration
{
    public class Configurator
    {
        public static APIConfiguration API => BindConfiguration<APIConfiguration>();
        public static BrowserConfiguration Browser => BindConfiguration<BrowserConfiguration>();
        public static IConfigurationRoot configurationRoot;

        static Configurator()
        {
            configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configs\\appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("Configs\\appsettings.custom.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static T BindConfiguration<T>() where T : IConfiguration, new()
        {
            var config = new T();
            configurationRoot.GetSection(config.SectionName).Bind(config);
            return config;
        }

        public static string GetValue(string key)
        {
            return configurationRoot[key];
        }
    }
}
