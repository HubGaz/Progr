using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Support
    {
        public void ContactSupport()
        {
            Console.WriteLine("Contact Support");

            string name = GetValidInput("Enter your name: ", "Name cannot be empty.");
            string email = GetValidEmail("Enter your email: ");
            string message = GetValidInput("Enter your message: ", "Message cannot be empty.");

            // Simulate sending the message to support
            Console.WriteLine("\nSending your message to support...");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Message: {message}");
            Console.WriteLine("Your message has been sent to support. We will get back to you shortly.");
        }

        private string GetValidInput(string prompt, string errorMessage)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(errorMessage);
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private string GetValidEmail(string prompt)
        {
            string email;
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email regex pattern

            do
            {
                Console.Write(prompt);
                email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, emailPattern))
                {
                    string message = "email format";
                    ErrorHandling.Error(message);
                    Console.WriteLine(" Please enter a valid email address.");
                }
            } while (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, emailPattern));

            return email;
        }
    }
}