﻿namespace Domain.Entities
{
   public class Display
    {
        string message;
        private Inventory _inventory;
        public Display(Inventory inventory) 
        {
            _inventory = inventory; 
        }
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
            Console.WriteLine("9. Remove multiple: ");
            Console.WriteLine("10. Contact Support");
            Console.WriteLine("11. Add Reservation");
            Console.WriteLine("12. Exit");
            Console.WriteLine("   ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What do you want to do ? :");
            
        }
        public void View()
        {
            List<Item> items = _inventory.GetItems(); 
            foreach (var item in items)
            {
                item.ViewInventory(); 
            }
        }
        public void ViewReserved()
        {
            var items = _inventory.GetItems(); 
            Console.WriteLine("Reserved Items:");
            foreach (var item in items)
            {
                if (item.ReservedQuantity > 0) 
                {
                    Console.WriteLine($"Item ID: {item.Id}, Name: {item.Name}, Reserved Quantity: {item.ReservedQuantity}");
                }
            }
        }
        public void Sort(){

            Console.WriteLine("Sort by:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Price");
            Console.Write("Enter your choice (1-3): ");

            if (!int.TryParse(Console.ReadLine(), out int sortChoice)){

                message = ", no item found";
                ErrorHandling.Error(message);
                return;
            }

            var items = _inventory.GetItems().ToList();

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

                    var itemById = _inventory.GetItems().FirstOrDefault(x => x.Id == searchId);
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

                    var itemsByName = _inventory.GetItems()
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
        public bool Exit(bool ShouldContinue)
        {
            Console.WriteLine("Do you want to Exit ? (yes/no)");
            string exitchoice = Console.ReadLine();
            if (exitchoice.Equals("yes"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Have a great day! ");
                Console.ForegroundColor = ConsoleColor.White;
                return false;

            }
            else if (exitchoice == "no")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Continuing the program...");
                Console.ForegroundColor = ConsoleColor.White;
                return true;    
            }
            else
            {
                message = "choice";
                ErrorHandling.Error(message);
                return true;
            }   
        }

    }
}
