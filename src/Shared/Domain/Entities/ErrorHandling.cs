
namespace Domain.Entities
{
  public class ErrorHandling
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid {message}");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
