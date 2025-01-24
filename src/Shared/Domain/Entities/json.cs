namespace Domain.Entities
{
    public class Json
    {
        private static readonly string JsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Progr", "src", "Files", "inventory.json"); 

        public static void SaveToJson(List<Item> items)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(JsonFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Directory created: {directoryPath}");
                }

                string jsonString = System.Text.Json.JsonSerializer.Serialize(items, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(JsonFilePath, jsonString);
                Console.WriteLine($"File saved: {JsonFilePath}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to JSON: {ex.Message}"); 
            }
        }
    }
}