using System.Text.Json;

namespace Domain.Entities
{
    public class json
    {
        private const string JsonFilePath = @"C:\Users\diabl\Documents\GitHub\Progr\src\Ur\inventory.json";

        public static void SaveInventory(List<Item> items)
        {
            try
            {
                Directory.CreateDirectory(@"C:\Users\diabl\Documents\GitHub\Progr\src\Ur\inventory.json");
                string jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions
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

        public static List<Item> LoadInventory()
        {
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    string jsonString = File.ReadAllText(JsonFilePath);
                    return JsonSerializer.Deserialize<List<Item>>(jsonString) ?? new List<Item>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from JSON: {ex.Message}");
            }

            // Return default items if file doesn't exist or there's an error
            return new List<Item>
            {
                new Item(1, "Laptop", 1200.50, 5),
                new Item(2, "Telewizor", 1600.00, 50),
                new Item(3, "Mikser", 1200.50, 5)
            };
        }
    }
}
