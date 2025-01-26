using Domain.Entities;

namespace Domain.Entities
{
    class Program
    {
        private Inventory _inventory;

        public Program()
        {
            _inventory = new Inventory(); 
        }

        static void Main(string[] args)
        {
            var program = new Program(); 
            program.Run(); 
        }

        public void Run()
        {
            var display = new Display(_inventory); 
            var editlist = new EditList(_inventory, display); 
            var support = new Support();
            bool shouldContinue = true;
            int choice;
            string message;

            do
            {
                display.Menu();
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    message = "choice";
                    ErrorHandling.Error(message);
                }

                switch (choice)
                {
                    case 1:
                        var items = _inventory.GetItems(); 
                        display.View();
                        break;

                    case 2:
                        editlist.Add();
                        break;

                    case 3:
                        editlist.AddMultiple();
                        break;

                    case 4:
                        display.Search();
                        break;

                    case 5:
                        display.Sort();
                        break;

                    case 6:
                        var itemsToSave = _inventory.GetItems();
                        Json.SaveToJson(itemsToSave);
                        break;

                    case 7:
                        editlist.Update();
                        break;

                    case 8:
                        editlist.Remove();
                        break;

                    case 9:
                        editlist.RemoveMultiple();

                        break;

                    case 10:
                        support.ContactSupport();
                        break;

                    case 11:
                        editlist.AddReservation();
                        break;

                    case 12:
                        shouldContinue = display.Exit(shouldContinue);
                        break;
                }
            } while (shouldContinue);
        }
    }
}