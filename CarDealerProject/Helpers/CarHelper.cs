using System;
using Services;

namespace CarDealerProject
{
    public class CarHelper
    {
        CarService carService;
        public CarHelper()
        {
            carService = new CarService();
        }
        public void ExecuteConsoleCommands()
        {
            ConsoleKeyInfo input;
            do
            {
                Console.Clear();
                Console.WriteLine("enter the number function (for exit press esc): \n" +
                    "1. Add \n" +
                    "2. Delete \n" +
                    "3. GetAllCars \n" +
                    "4. GetCar \n" +
                    "5. Update \n" +
                    "");
                input = Console.ReadKey(true);
                Console.Clear();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        carService.Add();
                        break;
                    case ConsoleKey.D2:
                        carService.Delete();
                        break;
                    case ConsoleKey.D3:
                        carService.GetAllCars();
                        break;
                    case ConsoleKey.D4:
                        carService.GetCar();
                        break;
                    case ConsoleKey.D5:
                        carService.Update();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
                Console.ReadKey();

            } while (input.Key != ConsoleKey.Escape);
        }
    }
}
