using Repositories.Abstract;
using Repositories.Concrete.ADO;

namespace Repositories.Factory
{
    public class ADOFactory : IFactory
    {
        public ICarRepository GetCarRepository()
        {
            return new CarRepository();
        }
    }
}
