using System.Collections.Generic;
using Models;

namespace Repositories.Abstract
{
    public interface ICarRepository
    {
        IEnumerable<tblCar> GetAllCars();

        tblCar GetCar(int id);
        bool Add(tblCar car);
        bool Delete(tblCar car);
        bool Update(tblCar car);
    }
}
