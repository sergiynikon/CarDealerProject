using System;
using Models;

namespace Services
{
    public class CarService: Service
    {
        public CarService()
        {
            Repositories = new CreateRepositories();
        }

        public bool Add()
        {
            Console.WriteLine("enter car details: ");
            Console.Write("Serial number: ");
            string serialNumber = Console.ReadLine();
            Console.Write("Make: ");
            string make = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Color: ");
            string color = Console.ReadLine();
            Console.Write("Year: ");
            short year = Convert.ToInt16(Console.ReadLine());
            Console.Write("Car for sale?: ");
            bool carForSale = Convert.ToBoolean(Console.ReadLine());

            Repositories.CarRepository.Add(new tblCar
            {
                SerialNumber = serialNumber,
                Make = make,
                Model = model,
                Color = color,
                Year = year,
                CarForSale = carForSale
            });
            Console.WriteLine("Car added successfully!");
            return true;
        }

        public bool Delete()
        {
            Console.Write("enter car id to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var car = new tblCar
            {
                Car_ID = id
            };
            var carSold = new tblCarsSold
            {
                Car_ID = id
            };
            //CarSoldRepository.Delete(carSold);
            Console.WriteLine("Car deleted successfully!");
            return Repositories.CarRepository.Delete(car);
        }

        public void GetAllCars()
        {
            foreach (var car in Repositories.CarRepository.GetAllCars())
            {
                Console.WriteLine($"" +
                    $"Car ID: {car.Car_ID}\n" +
                    $"Serial number: {car.SerialNumber}\n" +
                    $"Make: {car.Make}\n" +
                    $"Model: {car.Model}\n" +
                    $"Color: {car.Color}\n" +
                    $"Year: {car.Year}\n" +
                    $"Car for sale?: {car.CarForSale}\n");
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        public void GetCar()
        {
            Console.Write("enter car id: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            tblCar car = Repositories.CarRepository.GetCar(id);
            if (car != null)
            {
                Console.WriteLine($"" +
                    $"Car ID: {car.Car_ID}\n" +
                    $"Serial number: {car.SerialNumber}\n" +
                    $"Make: {car.Make}\n" +
                    $"Model: {car.Model}\n" +
                    $"Color: {car.Color}\n" +
                    $"Year: {car.Year}\n" +
                    $"Car for sale?: {car.CarForSale}\n");
            }
        }
        
        public bool Update()
        {
            Console.Write("enter car id to update: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            var dbCar = Repositories.CarRepository.GetCar(id);

            string line;
            if (dbCar != null)
            {
                Console.Write("serial number: ");
                line = Console.ReadLine();
                string serialNumber = line != "" ? line : dbCar.SerialNumber;

                Console.Write("make: ");
                line = Console.ReadLine();
                string make = line != "" ? line : dbCar.Make;

                Console.Write("model: ");
                line = Console.ReadLine();
                string model = line != "" ? line : dbCar.Model;

                Console.Write("color: ");
                line = Console.ReadLine();
                string color = line != "" ? line : dbCar.Color;

                Console.Write("year: ");
                line = Console.ReadLine();
                short year;
                if (line != "")
                    Int16.TryParse(line, out year);
                else
                    year = dbCar.Year;

                Console.Write("car for sale?: ");
                line = Console.ReadLine();
                bool carForSale = line != "" ? Convert.ToBoolean(line) : dbCar.CarForSale;


                Repositories.CarRepository.Update(new tblCar
                {
                    Car_ID = id,
                    SerialNumber = serialNumber,
                    Make = make,
                    Model = model,
                    Color = color,
                    Year = year,
                    CarForSale = carForSale
                });
            }
            Console.WriteLine("Car updated successfully!");
            return true;
        }
    }
}
