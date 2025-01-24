namespace Domain.Entities
{
    public class Json
    {
        private static readonly string JsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Progr", "src", "Files", "inventory.json"); // Path to save the JSON file

        public static void SaveToJson(List<Item> items)
        {
            try
            {
                // Ensure the directory exists
                string directoryPath = Path.GetDirectoryName(JsonFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath); // Create the directory if it doesn't exist
                    Console.WriteLine($"Directory created: {directoryPath}"); // Debugging output
                }

                string jsonString = System.Text.Json.JsonSerializer.Serialize(items, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(JsonFilePath, jsonString);
                Console.WriteLine($"File saved: {JsonFilePath}"); // Debugging output
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to JSON: {ex.Message}"); // Error message
            }
        }
    }
}