namespace WebMenuAPI
{
    static class ConfigurationManager
    {
        static ConfigurationManager()
        {
            AppSettings = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
        public static IConfiguration AppSettings
        {
            get;
        }
    }
}
