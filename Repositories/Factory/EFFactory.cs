using Repositories.Abstract;
using Repositories.Concrete.EF;

namespace Repositories.Factory
{
    public class EFFactory : IFactory
    {
        public ICarRepository GetCarRepository()
        {
            return new CarRepository();
        }
    }
}
