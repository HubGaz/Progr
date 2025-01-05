namespace Domain.Entities
{
   public class Display
    {
        string message;

        public void Menu()
        {

            Console.WriteLine("Menu:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ");
            Console.WriteLine("1. View inventory: ");
            Console.WriteLine("2. Add item: ");
            Console.WriteLine("3. Add multiple: ");
            Console.WriteLine("4. Search (for item): ");
            Console.WriteLine("5. Sort (Id/Name/Price): ");
            Console.WriteLine("6. Save to file: ");
            Console.WriteLine("7. Update: ");
            Console.WriteLine("8. Remove: ");
            Console.WriteLine("9. Exit");
            Console.WriteLine("   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What do you want to do ? :");
        }
        public void View(){

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
       public void Sort(){

            Console.WriteLine("Sort by:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Price");
            Console.Write("Enter your choice (1-3): ");

            if (!int.TryParse(Console.ReadLine(), out int sortChoice)){

                message = "choice";
                ErrorHandling.Error(message);
                return;
            }

            var items = Inventory.GetItems().ToList();

            switch (sortChoice){

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
                    
                    message = "choice";
                    ErrorHandling.Error(message);
                    return;
            }

            Console.WriteLine("\nSorted inventory:");
            foreach (var item in items){

                item.ViewInventory();
            }

        }

       public void Search(){

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Search by:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.Write("Enter your choice (1 or 2): ");

            if (!int.TryParse(Console.ReadLine(), out int searchChoice)){

                
                message = "choice";
                ErrorHandling.Error(message);

                return;
            }

            switch (searchChoice){

                case 1:
                    Console.Write("Enter id to search: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchId)){

                        message = "id";
                        ErrorHandling.Error(message);
                        return;
                    }

                    var itemById = Inventory.GetItems().FirstOrDefault(x => x.Id == searchId);
                    if (itemById != null){

                        Console.WriteLine("\nFound item:");
                        itemById.ViewInventory();
                    }
                    else{

                        message = "found";
                        ErrorHandling.Error(message);
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

                    if (itemsByName.Any()){

                        Console.WriteLine("\nFound items:");
                        foreach (var item in itemsByName){

                            item.ViewInventory();
                        }
                    }
                    else{


                        message = "found";
                        ErrorHandling.Error(message);
                    }
                    break;
            }
        }


    }
}
