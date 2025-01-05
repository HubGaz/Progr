namespace Domain.Entities
{
   public class Display
    {
        string message;
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

                int err = 1;
                message = "choice";
                ErrorHandling.Error(err, message);
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
                    int err = 1;
                    message = "choice";
                    ErrorHandling.Error(err, message);
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

                int err = 1;
                message = "choice";
                ErrorHandling.Error(err, message);

                return;
            }

            switch (searchChoice){

                case 1:
                    Console.Write("Enter id to search: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchId)){

                        int err = 1;
                        message = "id";
                        ErrorHandling.Error(err, message);
                        return;
                    }

                    var itemById = Inventory.GetItems().FirstOrDefault(x => x.Id == searchId);
                    if (itemById != null){

                        Console.WriteLine("\nFound item:");
                        itemById.ViewInventory();
                    }
                    else{

                        int err = 2;
                        message = "found";
                        ErrorHandling.Error(err, message);
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

                        int err = 2;
                        message = "found";
                        ErrorHandling.Error(err, message);
                    }
                    break;
            }
        }


    }
}
