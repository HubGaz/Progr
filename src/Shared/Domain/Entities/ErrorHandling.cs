
namespace Domain.Entities
{
  public class ErrorHandling
    {
        public static void Error(int err, string message)
        {
            switch (err){

                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Invalid {message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("no item found");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }

        }
    }
}
