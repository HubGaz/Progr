using Domain.Entities;

public class Inventory : IInventory
{
    private const string JsonFilePath = @"..\Progr\src\Files";

    private static List<Item> _items = new List<Item>();

    public List<Item> GetItems()
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

    public bool ItemExists(int itemId)
    {
        return _items.Any(item => item.Id == itemId);
    }

    public bool CanReserve(int itemId, int amount)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        return item != null && item.Quantity >= amount;
    }

    public void ReserveItem(int itemId, int amount)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item != null && item.Quantity >= amount)
        {
            item.Quantity -= amount;
            item.ReservedQuantity += amount;
        }
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
}