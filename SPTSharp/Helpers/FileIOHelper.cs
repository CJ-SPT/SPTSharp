using Newtonsoft.Json;

namespace SPTSharp.Helpers
{
    public static class FileIOHelper
    {
        public static string dataPath = Path.Combine(AppContext.BaseDirectory, "Aki_Data");
        public static string profilePath = Path.Combine(AppContext.BaseDirectory, "user", "profiles");

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Logger.LogInfo("");
            }
        }

        // Loads json from `SPTSharp/folderName/subFolderName/fileName.json`
        public static T LoadJson<T>(string[] path)
        {
            var p = Path.Combine(path);

            try
            {
                string json = File.ReadAllText(p);
                #pragma warning disable CS8603
                return JsonConvert.DeserializeObject<T>(json);
                #pragma warning restore CS8603
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON from file '{p}': {ex.Message}");
                #pragma warning disable CS8603
                return default; // Return default value for the type T in case of an error
                #pragma warning restore CS8603
            }
        }

        // Saves json to disk
        public static void SaveJson(string[] path, object obj)
        {
            var p = Path.Combine(path);

            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
                   
            File.WriteAllText(p, jsonString);
        }

        public static Dictionary<string, Dictionary<string, string>> LoadLocaleData(string[] directory)
        {
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();

            var path = Path.Combine(directory);

            // Get all JSON files in the current directory
            string[] jsonFiles = Directory.GetFiles(path, "*.json");

            foreach (var jsonFile in jsonFiles)
            {
                // Load JSON content from the file
                string jsonContent = File.ReadAllText(jsonFile);

                try
                {
                    // Deserialize JSON to a Dictionary<string, string>
                    var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);

                    // Get the file name without extension as the key
                    string fileName = Path.GetFileNameWithoutExtension(jsonFile);

                    // Add the data to the result dictionary
                    result.Add(fileName, data);
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error loading {jsonFile}: {ex.Message}");
                }
            }

            return result;
        }

        // Recursively gets all file names for a given directory
        public static string[] GetFileNames(string[] path)
        {
            try
            { 
                return Directory.GetFiles(Path.Combine(path), "*.*", SearchOption.AllDirectories); ;
            }
            catch (Exception e)
            {
                Logger.LogException(e);
                return new string[0];
            }
        }

        public static string GetSptDataPath()
        {
            return "Aki_Data/Server/";
        }
    }
}
