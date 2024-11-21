namespace Domain.Entities;
class Program { 
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
            switch (choice) { 
            
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
                    Inventory.AddItem();
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
