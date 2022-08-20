namespace MovieRecommendationApp.Api.Configuration
{
    static class Configurations
    {
        static public string ConnectingString
        {
            get
            {
                //Bu sınıf sayesinde json dosyalarını hızlı bir şekilde okuyup içerisinde ki verilieri önbelleğe alabiliyoruz.
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ""));
                configurationManager.AddJsonFile("appsetting.json");

                return configurationManager.GetConnectionString("DefaultConnection");
            }
        }
    }
}
