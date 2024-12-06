
 public class Inventory
{
    private static List<Item> _items = new List<Item>();
    private const string JsonFilePath = @"C:\Users\diabl\Documents\GitHub\Progr\src\Ur\inventory.json";
    public static List<Item> GetItems()
    {
        if (!_items.Any())
        {
            _items = new List<Item>
            {
                new Item(1, "Laptop", 1200.50, 5),
                new Item(2, "Telewizor", 1600.00, 50),
                new Item(3, "Mikser", 1200.50, 5)
            };
        }
        return _items;
    }

    public static void AddItem(Item item)
    {
        _items.Add(item);
        
    }
    public static void SaveToJson()
    {
        string jsonString = System.Text.Json.JsonSerializer.Serialize(_items);
        File.WriteAllText(JsonFilePath, jsonString);
    }

}
