
namespace Domain.Entities
{
    public class Support
    {
        public void ContactSupport()
        {
            Console.WriteLine("Contact Support");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your message: ");
            string message = Console.ReadLine();

            // Simulate sending the message to support
            Console.WriteLine("\nSending your message to support...");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("Your message has been sent to support. We will get back to you shortly.");
        
    }
    }
}
