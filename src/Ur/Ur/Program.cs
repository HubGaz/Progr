namespace Domain.Entities;
class Program
{
    static void Main(string[] args)
    {
        bool Doit = true;
        int choice;
        string message;
        var display = new Display();
        var editlist = new EditList();

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
                ErrorHandling.Error(err, message);
            }
            
            switch (choice)
            {

                case 1:
                    var items = Inventory.GetItems();
                    
                    display.View();
                    break;

                case 2:

                    editlist.Add();

                    break;

                case 3:
                    
                    display.Search();
                    break;

                case 4:
                    display.Sort();
                   
                    break;

                case 5:
                    var itemsToSave = Inventory.GetItems(); 
                    json.SaveToJson(itemsToSave);
                    break;
                case 6:
                    editlist.Update();
                    break;
                case 7:
                    editlist.Remove();
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
