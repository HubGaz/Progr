namespace Domain.Entities;
class Program
{
    static void Main(string[] args)
    {
        bool Doit = true;
        int choice;

         void Add()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dodaj nowy przedmiot:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter item ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong ID (needs to be number)");
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid price. Item not added.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.Write("Enter item quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid quantity. Item not added.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var newItem = new Item(id, name, price, quantity);
            Inventory.AddItem(newItem);
        }

        void Search()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Search by:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.Write("Enter your choice (1 or 2): ");

            if (!int.TryParse(Console.ReadLine(), out int searchChoice))
            {
                Console.WriteLine("Invalid choice. Returning to main menu.");
                return;
            }

            switch (searchChoice)
            {
                case 1:
                    Console.Write("Enter ID to search: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchId))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid ID format.");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;
                    }

                    var itemById = Inventory.GetItems().FirstOrDefault(x => x.Id == searchId);
                    if (itemById != null)
                    {
                        Console.WriteLine("\nFound item:");
                        itemById.ViewInventory();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No item found with that ID.");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    break;

                case 2:
                    Console.Write("Enter name to search: ");
                    string searchName = Console.ReadLine().ToLower();

                    var itemsByName = Inventory.GetItems()
                        .Where(x => x.Name.ToLower().Contains(searchName))
                        .ToList();

                    if (itemsByName.Any())
                    {
                        Console.WriteLine("\nFound items:");
                        foreach (var item in itemsByName)
                        {
                            item.ViewInventory();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No items found with that name.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        void Sort()
        {

            Console.WriteLine("Sort by:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Price");
            Console.Write("Enter your choice (1-3): ");

            if (!int.TryParse(Console.ReadLine(), out int sortChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Returning to main menu.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var items = Inventory.GetItems().ToList();

            switch (sortChoice)
            {
                case 1:
                    items = items.OrderBy(x => x.Id).ToList();
                    break;
                case 2:
                    items = items.OrderBy(x => x.Name).ToList();
                    break;
                case 3:
                    items = items.OrderBy(x => x.Price).ToList();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
            }

            Console.WriteLine("\nSorted inventory:");
            foreach (var item in items)
            {
                item.ViewInventory();
            }
        
    }
        do
        {
            
            Console.WriteLine("Menu:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ");
            Console.WriteLine("1. View inventory: ");
            Console.WriteLine("2. Add item: ");
            Console.WriteLine("3. Search (for item): ");
            Console.WriteLine("4. Sort (Id/Name/Price): ");
            Console.WriteLine("5. Save to file: ");
            Console.WriteLine("6. Exit: ");
            Console.WriteLine("   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What do you want to do ? :");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice, choose again ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            switch (choice)
            {

                case 1:
                    var items = Inventory.GetItems();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Lista przedmiotów:");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var item in items)
                    {
                        item.ViewInventory();
                    }
                    Console.WriteLine("   ");
                    break;

                case 2:

                    Add();

                    break;

                case 3:
                    Search();
                    break;

                case 4:
                    Sort();
                   
                    break;

                case 5:
                    Inventory.SaveToJson();
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Have a great day");
                    Console.ForegroundColor = ConsoleColor.White;
                    Doit = false;
                    break;
                
            };
        } while (Doit);




    }
}
