public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    // Konstruktor domyślny
    public Item() : this(0, "Unknown", 0, 1)
    {
    }

    // Konstruktor z Id
    public Item(int id) : this(id, "Unknown", 0, 1)
    {
    }

    // Konstruktor z Name
    public Item(string name) : this(0, name, 0, 1)
    {
    }

    // Konstruktor z Name i Price
    public Item(string name, decimal price) : this(0, name, price, 1)
    {
    }

    // Konstruktor z pełnymi parametrami
    public Item(int id, string name, decimal price, decimal quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        TotalPrice = price * quantity;
    }
}
