
namespace Domain.Entities;
class Program
{
    static void Main(string[] args)
    {
        var display = new Display();
        var editlist = new EditList(display);
        var support = new Support();
        bool Doit = true;
        int choice;
        string message;

        do{
            
            display.Menu();
            if (!int.TryParse(Console.ReadLine(), out choice)){

                message = "choice";
                ErrorHandling.Error(message);
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
                    editlist.AddMultiple();
                    break;

                case 4:
                    
                    display.Search();
                    break;

                case 5:

                    display.Sort();
                    break;

                case 6:

                    var itemsToSave = Inventory.GetItems(); 
                    json.SaveToJson(itemsToSave);
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
                    Console.WriteLine("Do you want to Exit ? (yes/no)");
                    string exitchoice = Console.ReadLine();
                    if (exitchoice == "yes")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Have a great day! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Doit = false;

                    }else if (exitchoice == "no")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Continuing the program...");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        message = "choice";
                        ErrorHandling.Error(message);
                    }
                    break;
            };
        } while (Doit);
    }
}
