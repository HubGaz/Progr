namespace Domain.Entities
{
    public class Json
    {
        private const string JsonFilePath = @"C:\Users\diabl\Documents\GitHub\Progr\src\Ur\inventory.json";

        public static void SaveToJson(List<Item> items)
        {
            try
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(items, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(JsonFilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to JSON: {ex.Message}");
            }
        }
    }
}