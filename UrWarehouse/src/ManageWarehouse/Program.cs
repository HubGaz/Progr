﻿
using UrWarehouse;

namespace ManageWarehouse
{
    internal class Program
    {
        private static Mainhouse _manager = null!;
        private static string[] _menuItems = new string[]
        {
            "View inventory",
            "Add item",
            "Search",
            "Exit"
        };
        static int GetNumber(int max,int min = 0){
                int input;
                while (true)
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= min && input <= max)
                    {
                        return input;
                    }
                }
                Console.WriteLine($"Invalid input. ({min} - {max})");
            }
        }
        static void Main()
        {
            _manager = new Mainhouse();

            Console.WriteLine("Welcome to BundaHub!");
            while (true)
            {
                // Display the menu 
                for (int i = 0; i < _menuItems.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {_menuItems[i]}");
                }
                
                // Get user input
                int choice = GetNumber(_menuItems.Length, 1);

                switch (choice)
                {
                    case 1:
                        _manager.ViewInventory();
                        break;
                    case 2:
                        _manager.AddItem();
                        break;
                    case 3:
                        _manager.Search();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye! - Thank you for using BundaHub.");
                        return;
                }
    }
}
    }
}
