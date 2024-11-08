namespace UrWarehouse{

    class Mainhouse{
        private Item[] inventory = new Item[]{};

        public Mainhouse(){
            inventory = new Item[]{
                new Item(1,"Przedmiot 1",100,2),
                new Item(2,"Przedmiot 2",33,300),
                new Item(3,"Przedmiot 3",1,200),
                new Item(4,"Przedmiot 4",5,13),
                new Item(5,"Przedmiot 5",8,10),
                new Item(6,"Przedmiot 6",13,100000)
            };
        }
                    public void ViewInventory()
        {
            // Calculate the column sizes based on the biggest item in each column
            int[] colSizes = {
                inventory.Max(i => i.Name.Length),
                inventory.Max(i => i.Price.ToString().Length),
                inventory.Max(i => i.Quantity.ToString().Length),
                inventory.Max(i => i.TotalPrice.ToString().Length)
            };

            // the colSize could be smaller than the column header
            if (colSizes[0] < "Inventory:".Length) colSizes[0] = "Inventory:".Length;
            if (colSizes[1] < "Price".Length) colSizes[1] = "Price".Length;
            if (colSizes[2] < "Quantity".Length) colSizes[2] = "Quantity".Length;
            if (colSizes[3] < "Total Price".Length) colSizes[3] = "Total Price".Length;

            // header row
            Console.Write("Inventory:".PadLeft(colSizes[0]));
            Console.Write("Price".PadLeft(colSizes[1] + 2));
            Console.Write("Quantity".PadLeft(colSizes[2] + 2));
            Console.WriteLine("Total Price".PadLeft(colSizes[3] + 2));

            // separator line
            Console.WriteLine(new string('-', colSizes.Sum() + 10));
            
            // each item row
            foreach (Item item in inventory)
            {
                Console.Write(" ID: " + item.Id + " ");
                Console.Write(" Name: " + item.Name  + " " );
                Console.Write(" Price: " + item.Price.ToString()  + " " );
                Console.Write(" Quantity: " + item.Quantity.ToString()  + " ");
                Console.WriteLine(" Total Price: " + item.TotalPrice.ToString()  + " ");
            }

            // separator line
            Console.WriteLine(new string('-', colSizes.Sum() + 10));
        }
        public void AddItem(){
            Console.WriteLine("Adding item...");
                            
                            Console.WriteLine("Enter item ID :");
                            if(!int.TryParse(Console.ReadLine(), out int Id))
                             {
                                Console.WriteLine("Invalid ID");
                                return;
                             }

                            Console.Write("Enter item name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter item price: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                            {
                                Console.WriteLine("Invalid price. Item not added.");
                                return;
                            }

                            Console.Write("Enter item quantity: ");
                            if (!int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                Console.WriteLine("Invalid quantity. Item not added.");
                                return;
                            }

                            Item newItem = new Item(Id,name, price, quantity);
                            Array.Resize(ref inventory, inventory.Length + 1);
                            inventory[^1] = newItem;

                            Console.WriteLine("Item added successfully.");  
        }
        public void Search(){
             Console.WriteLine("Search by (name/price/quantity): ");
    string searchBy = Console.ReadLine()?.ToLower(); 

    switch (searchBy)
    {
        case "name":
            Console.Write("Enter item name to search: ");
            string name = Console.ReadLine();
            var nameResults = inventory.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplaySearchResults(nameResults);
            break;

        case "price":
            Console.Write("Enter minimum price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
            {
                Console.WriteLine("Invalid price.");
                return;
            }
            Console.Write("Enter maximum price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
            {
                Console.WriteLine("Invalid price.");
                return;
            }
            var priceResults = inventory.Where(i => i.Price >= minPrice && i.Price <= maxPrice).ToList();
            DisplaySearchResults(priceResults);
            break;
        
        case "quantity":
            Console.Write("Enter minimum quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int minQuantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }
            Console.Write("Enter maximum quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int maxQuantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }
            var quantityResults = inventory.Where(i => i.Quantity >= minQuantity && i.Quantity <= maxQuantity).ToList();
            DisplaySearchResults(quantityResults);
            break;


        default:
            Console.WriteLine("Invalid search criteria. Choose either 'name', 'price', or 'quantity'.");
            break;
        }

        }
         private void DisplaySearchResults(List<Item> results)
{
    if (results.Count > 0)
    {
        Console.WriteLine("Search Results:");
        foreach (var item in results)
        {
            Console.WriteLine($"{item.Name}, Price: {item.Price}, Quantity: {item.Quantity}, Total Price: {item.TotalPrice}");
        }
    }
    else
    {
        Console.WriteLine("No items found.");
    }
    Console.WriteLine(" ");
}
    }
}

