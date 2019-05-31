using Repositories.Abstract;
using System;
using Repositories.Factory;
using Models;

namespace CarDealerProject
{
    class Program
    {

        static void Main(string[] args)
        {
            CarHelper carHelper;
            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine("enter the number of table (for exit press esc): \n" +
                    "1. tblCar \n" +
                    "");
                input = Console.ReadKey(true);
                Console.Clear();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        carHelper = new CarHelper();
                        carHelper.ExecuteConsoleCommands();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            } while (input.Key != ConsoleKey.Escape);
        }
    }
}
