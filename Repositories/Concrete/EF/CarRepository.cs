using System;
using System.Collections.Generic;
using Models;
using Repositories.Abstract;
using System.Linq;

namespace Repositories.Concrete.EF
{
    public class CarRepository : ICarRepository
    {
        public bool Add(tblCar car)
        {
            using (var dbContext = new CarDealerDBEntities())
            {
                dbContext.tblCars.Add(car);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool Delete(tblCar car)
        {
            using (var dbContext = new CarDealerDBEntities())
            {
                var dbCar = dbContext.tblCars.FirstOrDefault(x => x.Car_ID == car.Car_ID);
                if (dbCar != null)
                {
                    dbContext.tblCars.Remove(dbCar);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<tblCar> GetAllCars()
        {
            using (var dbContext = new CarDealerDBEntities())
            {
                return dbContext.tblCars.ToList();
            }
        }

        public tblCar GetCar(int id)
        {
            using (var dbContext = new CarDealerDBEntities())
            {
                var dbCar = dbContext.tblCars.FirstOrDefault(x => x.Car_ID == id);
                return dbCar;
            }
        }

        public bool Update(tblCar car)
        {
            using (var dbContext = new CarDealerDBEntities())
            {
                var old = dbContext.tblCars.FirstOrDefault(x => x.Car_ID == car.Car_ID);
                old.SerialNumber = car.SerialNumber;
                old.Make = car.Make;
                old.Model = car.Model;
                old.Color = car.Color;
                old.Year = car.Year;
                old.CarForSale = car.CarForSale;
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
