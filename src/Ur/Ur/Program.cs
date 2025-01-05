using System.ComponentModel.Design;

namespace Domain.Entities;
class Program
{
    static void Main(string[] args)
    {
        var display = new Display();
        var editlist = new EditList();
        bool Doit = true;
        int choice;
        string message;

        do{
            display.Menu();


            if (!int.TryParse(Console.ReadLine(), out choice)){

                int err = 1;
                message = "choice";
                ErrorHandling.Error(err, message);
            }
            
            switch (choice){

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
