namespace Domain.Entities
{
    public class EditList
    {
        string message;
        private Display display;
        private Inventory _inventory;
        public EditList(Inventory inventory) 
        {
            _inventory = inventory; 
        }
        public void Add()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dodaj nowy przedmiot:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter item ID: ");

            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {

                Console.ForegroundColor = ConsoleColor.Red;
                message = "id";
                ErrorHandling.Error(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
           
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {

                message = "price";
                ErrorHandling.Error(message);
                return;
            }

            Console.Write("Enter item quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {

                message = "quantity";
                ErrorHandling.Error(message);
                return;
            }

            var newItem = new Item(id, name, price, quantity);
            if (_inventory.ItemExists(newItem.Id))
            {
                Console.WriteLine($"Item with ID {newItem.Id} already exists. Item not added.");
                return;
            }
            _inventory.AddItem(newItem);
        }

        public void AddMultiple()
        {
            Console.WriteLine("How many item do you want to add ? ");
            int ile;

            if (!int.TryParse(Console.ReadLine(), out ile))
            {

                string message = "number";
                ErrorHandling.Error(message);
            }

            for (int i = 0; i < ile; i++)
            {

                Add();
                Console.WriteLine("    ");
            }
        }

        public void Update()
        {

            var items = _inventory.GetItems();
            int ilosc = items.Count;

            Console.WriteLine("Enter number of item to update: ");
            if (!int.TryParse(Console.ReadLine(), out int selection) || selection < 1 || selection > ilosc)
            {

                message = "choice";
                ErrorHandling.Error(message);
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

                    message = "price";
                    ErrorHandling.Error(message);
                }
            }

            Console.Write("\nEnter new quantity (press Enter to keep current): ");
            string quantityInput = Console.ReadLine();
            int newQuantity = (int)selectedItem.Quantity;

            if (!string.IsNullOrWhiteSpace(quantityInput))
            {

                if (!int.TryParse(quantityInput, out newQuantity))
                {

                    message = "quantity";
                    ErrorHandling.Error(message);
                }
            }

            selectedItem.Name = newName;
            selectedItem.Price = newPrice;
            selectedItem.Quantity = newQuantity;


            Console.WriteLine("\nItem Updated Succesfully");


        }
        public void Remove()
        {


            Console.WriteLine("Enter the ID of the item to remove:");
            if (int.TryParse(Console.ReadLine(), out int itemId))
            {
                var itemToRemove = _inventory.GetItems().FirstOrDefault(item => item.Id == itemId);
                if (itemToRemove != null)
                {
                    _inventory.GetItems().Remove(itemToRemove);
                    Console.WriteLine($"Item with ID {itemId} has been removed.");
                }
                else
                {
                    Console.WriteLine($"No item found with ID {itemId}.");
                }
            }
            else
            {
                message = "id";
                ErrorHandling.Error(message);
            }
        }
        public void RemoveMultiple()
        {

            Console.WriteLine("How many to remove ?");
            int ile;
            if (!int.TryParse(Console.ReadLine(), out ile))
            {

                string message = "amount";
                ErrorHandling.Error(message);
            }
            else
            {

                for (int i = 0; i < ile; i++)
                {

                    Remove();
                    Console.WriteLine("\nItem removed succesfully ");
                }
            }
        }
        public void AddReservation()
        {
            Console.WriteLine("Enter item ID to reserve:");
            int itemId = int.Parse(Console.ReadLine());

            if (!_inventory.ItemExists(itemId))
            {
                Console.WriteLine("Item not found or already reserved.");
                return;
            }
            {
                Console.WriteLine("Enter the amount to reserve:");
                int amountToReserve = int.Parse(Console.ReadLine());


                if (!_inventory.CanReserve(itemId, amountToReserve))
                {
                    Console.WriteLine("Not enough items available to reserve.");
                    return;
                }
                _inventory.ReserveItem(itemId, amountToReserve);
                Console.WriteLine($"Reserved {amountToReserve} of item {itemId}.");

                display.ViewReserved();

            }
        }
    }
}


    

