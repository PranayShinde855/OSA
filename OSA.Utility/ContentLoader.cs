using Newtonsoft.Json;

namespace OSA.Utility
{
    public static class ContentLoader
    {
        public static Dictionary<string, string> en_US = new Dictionary<string, string>();
        public static void LanguageLoader()
        {
            try
            {
                if (en_US != null && en_US.Count > 0)
                {
                    string languageFilePath = Path.Combine(Utils.RootPath, "Content\\en-Us.json");
                    var readData = File.ReadAllText(languageFilePath);

                    var _en_Us = JsonConvert.DeserializeObject<Dictionary<string, string>>(readData);
                    if (_en_Us != null) en_US = _en_Us;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReturnedLanguage(string key, string language = "en_Us")
        {
            try
            {
                switch (language)
                {
                    case "en_Us":
                        return en_US[key];
                    default:
                        return en_US[key];

                }
            }
            catch
            {
                return key;
            }
        }
    }
}
