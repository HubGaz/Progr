using System.Diagnostics;

namespace Domain.Entities;
class Program
{
    static void Main(string[] args)
    {
        bool Doit = true;
        int choice;
        string message;
        void View()
        {
            var items = Inventory.GetItems();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lista przedmiotów:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in items)
            {
                item.ViewInventory();
            }
            Console.WriteLine("   ");
        }
         void Error(int err, string message)
        {
            switch (err) {

                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Invalid {message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("no item found");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

    }

        }

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
                int err = 1;
                message = "id";
                Error(err,message);
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                int err = 1;
                message = "price";
                Error(err,message);
                return;
            }

            Console.Write("Enter item quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                int err = 1;
                message = "quantity";
                Error(err,message);
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

            if (!int.TryParse(Console.ReadLine(), out int searchChoice)){
                int err = 1;
                message = "choice";
                Error(err,message);
                
                return;
            }

            switch (searchChoice)
            {
                case 1:
                    Console.Write("Enter id to search: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchId))
                    {
                        int err = 1;
                        message = "id";
                        Error(err,message);
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
                        int err = 2;
                        message = "found";
                        Error(err,message);   
                    }
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Enter name to search: ");
                    Console.ForegroundColor = ConsoleColor.White;

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
                        
                        int err = 2;
                        message = "found";
                        Error(err,message);
                    }
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
                int err = 1;
                message = "choice";
                Error(err, message);
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
                    int err = 1;
                    message = "choice";
                    Error(err, message);
                    return;
            }

            Console.WriteLine("\nSorted inventory:");
            foreach (var item in items)
            {
                item.ViewInventory();
            }
        
    }
        void Update()
        {
            var items = Inventory.GetItems();
            int ilosc = items.Count;

            Console.WriteLine("Enter number of item to update: ");
            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > ilosc)
            {
                int err = 1;
                message = "choice";
                Error(err, message);
            }

            var selectedItem = items[selection - 1];

            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {

                newName = selectedItem.Name;
            }

            Console.Write("\nEnter new price (press Enter to keep current): ");
            string priceInput = Console.ReadLine();
            double newPrice = selectedItem.Price;

            if (!string.IsNullOrWhiteSpace(priceInput))
            {

                if (!double.TryParse(priceInput, out newPrice))
                {
                    int err = 1;
                    message = "price";
                    Error(err, message);
                }
            }

            Console.Write("\nEnter new quantity (press Enter to keep current): ");
            string quantityInput = Console.ReadLine();
            int newQuantity = (int)selectedItem.Quantity;

            if (!string.IsNullOrWhiteSpace(quantityInput))
            {

                if (!int.TryParse(quantityInput, out newQuantity))
                {
                    int err = 1;
                    message = "quantity";
                    Error(err, message);
                }
            }

            selectedItem.Name = newName;
            selectedItem.Price = newPrice;
            selectedItem.Quantity = newQuantity;


            Console.WriteLine("\nItem Updated Succesfully");


        }
    void Remove() {
        
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
            Console.WriteLine("6. Update: ");
            Console.WriteLine("7. Remove: ");
            Console.WriteLine("8. Exit");
            Console.WriteLine("   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What do you want to do ? :");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                int err = 1;
                message = "choice";
                Error(err, message);
            }
            switch (choice)
            {

                case 1:
                    var items = Inventory.GetItems();

                    View();
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
                    Update();
                    break;
                case 7:
                    Remove();
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Have a great day");
                    Console.ForegroundColor = ConsoleColor.White;
                    Doit = false;
                    break;
                
            };
        } while (Doit);




    }
}
