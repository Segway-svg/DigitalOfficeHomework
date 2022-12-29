using Microsoft.Extensions.Configuration;

namespace DigitalOfficeHomework.FileConfiguration
{
    public static class ConfigureJson
    {
        public static PathClientConfig GetPaths()
        {
            IConfigurationSection section = GetConfigurationRoot().GetSection(nameof(PathClientConfig));
            return section.Get<PathClientConfig>();
        }

        private static IConfigurationRoot GetConfigurationRoot()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(path: "appsettings.json", false, true)
                .Build();
            return config;
        }
    }
}