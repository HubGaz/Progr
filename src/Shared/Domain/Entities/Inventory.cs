
 public class Inventory
{
    private const string JsonFilePath = @"C:\Users\diabl\Documents\GitHub\Progr\src\Ur\inventory.json";

    private static List<Item> _items = new List<Item>();

    
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
    public static bool ItemExists(int itemId)
    {
        return _items.Any(item => item.Id == itemId); 
    }

    public static bool CanReserve(int itemId, int amount)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        return item != null && item.Quantity >= amount; 
    }

    public static void ReserveItem(int itemId, int amount)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null && item.Quantity >= amount)
        {
            item.Quantity -= amount; 
            item.ReservedQuantity += amount; 
        }
    }

    public static void AddItem(Item item)
    {
        _items.Add(item);
        
    }
    

}
