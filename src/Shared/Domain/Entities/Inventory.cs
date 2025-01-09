
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
        return _items.Any(item => item.Id == itemId && !item.IsReserved);
    }
    public static bool CanReserve(int itemId, int amount)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        return item != null && item.Quantity >= amount && !item.IsReserved; // Check if enough items are available
    }

    public static void ReserveItem(int itemId, int amount)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null && item.Quantity >= amount)
        {
            item.Quantity -= amount; // Decrease the available quantity
            item.IsReserved = true; // Mark the item as reserved
        }
    }

    public static void AddItem(Item item)
    {
        _items.Add(item);
        
    }
    

}
