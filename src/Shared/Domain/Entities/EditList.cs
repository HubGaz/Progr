namespace Domain.Entities
{
    public class EditList
    {
        string message;
        public void Add()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dodaj nowy przedmiot:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter item ID: ");

            int id;

            while (!int.TryParse(Console.ReadLine(), out id)){

                Console.ForegroundColor = ConsoleColor.Red;
                int err = 1;
                message = "id";
                ErrorHandling.Error(err, message);
                Console.ForegroundColor = ConsoleColor.White;
            }


            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item price: ");
            if (!double.TryParse(Console.ReadLine(), out double price)){

                int err = 1;
                message = "price";
                ErrorHandling.Error(err, message);
                return;
            }

            Console.Write("Enter item quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity)){

                int err = 1;
                message = "quantity";
                ErrorHandling.Error(err, message);
                return;
            }

            var newItem = new Item(id, name, price, quantity);
            Inventory.AddItem(newItem);
        }

       public void Update(){

            var items = Inventory.GetItems();
            int ilosc = items.Count;

            Console.WriteLine("Enter number of item to update: ");
            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > ilosc){

                int err = 1;
                message = "choice";
                ErrorHandling.Error(err, message);
            }

            var selectedItem = items[selection - 1];

            Console.WriteLine("Enter new name:");
            string newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName)){

                newName = selectedItem.Name;
            }

            Console.Write("\nEnter new price (press Enter to keep current): ");
            string priceInput = Console.ReadLine();
            double newPrice = selectedItem.Price;

            if (!string.IsNullOrWhiteSpace(priceInput)){

                if (!double.TryParse(priceInput, out newPrice)){

                    int err = 1;
                    message = "price";
                    ErrorHandling.Error(err, message);
                }
            }

            Console.Write("\nEnter new quantity (press Enter to keep current): ");
            string quantityInput = Console.ReadLine();
            int newQuantity = (int)selectedItem.Quantity;

            if (!string.IsNullOrWhiteSpace(quantityInput)){

                if (!int.TryParse(quantityInput, out newQuantity)){

                    int err = 1;
                    message = "quantity";
                    ErrorHandling.Error(err, message);
                }
            }

            selectedItem.Name = newName;
            selectedItem.Price = newPrice;
            selectedItem.Quantity = newQuantity;


            Console.WriteLine("\nItem Updated Succesfully");


        }
        public void Remove(){

            {
                Console.WriteLine("Enter the ID of the item to remove:");
                if (int.TryParse(Console.ReadLine(), out int itemId))
                {
                    var itemToRemove = Inventory.GetItems().FirstOrDefault(item => item.Id == itemId);
                    if (itemToRemove != null)
                    {
                        Inventory.GetItems().Remove(itemToRemove);
                        Console.WriteLine($"Item with ID {itemId} has been removed.");
                    }
                    else
                    {
                        Console.WriteLine($"No item found with ID {itemId}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }

        }

    }
}
