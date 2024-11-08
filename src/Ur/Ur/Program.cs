using System.Threading.Channels;

namespace Domain.Entities;

class Program { 
static void Main(string[] args)
{
        bool Doit = true;
        int choice;
        do
        {
            Console.WriteLine("What do you want to do ? :");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice, choose again ");
            }
            switch (choice) { 
            case 1:

            break;
            };
        } while (Doit);
            
            
               
       
}
}
