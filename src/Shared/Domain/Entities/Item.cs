
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public bool IsReserved { get; set; }
    public Item(int id, string name, double price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void ViewInventory()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Price: ${Price:F2}, Quantity: {Quantity}");
    }

}

