namespace UrWarehouse
{
    class Item
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        private static int _idCounter = 0; // Prywatne pole statyczne do generowania unikalnych Id

        public Item(string name) : this(name, 0, 1)
        {
        }
        public Item(string name, decimal price) : this(name, price, 1)
        {   
        }
        public Item(string name, decimal price, int quantity)
        {
            Id = ++_idCounter; 
            Name = name;
            Price = price;
            Quantity = quantity;
            TotalPrice = price * quantity;
        }
    }
}
