namespace Domain.Entities;
class Program
{
    static void Main(string[] args)
    {
        bool Doit = true;
        int choice;


        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("   ");
            Console.WriteLine("1. View inventory: ");
            Console.WriteLine("2. Add item: ");
            Console.WriteLine("3. Search (for item): ");
            Console.WriteLine("4. Sort (Id/Name/Price): ");
            Console.WriteLine("5. Exit: ");
            Console.WriteLine("   ");
            Console.WriteLine("What do you want to do ? :");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice, choose again ");
            }
            switch (choice)
            {

                case 1:
                    var items = Inventory.GetItems();
                    Console.WriteLine("Lista przedmiotów:");
                    foreach (var item in items)
                    {
                        item.ViewInventory();
                    }
                    Console.WriteLine("   ");
                    break;

                case 2:
                    Console.WriteLine("Dodaj nowy przedmiot:");
                    Console.WriteLine("Enter item ID: ");
                    int id;
                    while(!int.TryParse(Console.ReadLine(), out id))
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
                        Console.WriteLine("Invalid price. Item not added.");
                        return;
                    }

                    Console.Write("Enter item quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity))
                    {
                        Console.WriteLine("Invalid quantity. Item not added.");
                        return;
                    }

                    var newItem = new Item(id, name, price, quantity);
                    Inventory.AddItem(newItem);



                    break;

                case 3:
                    void Search() { };
                    Console.WriteLine("   ");
                    break;

                case 4:
                    void Sort() { };
                    Console.WriteLine("   ");
                    break;

                case 5:
                    Console.WriteLine("Have a great day");
                    Doit = false;
                    break;
            };
        } while (Doit);




    }
}
