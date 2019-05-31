using Repositories.Abstract;
using Repositories.Factory;

namespace Services
{
    public class CreateRepositories
    {
        public ICarRepository CarRepository { get; }
        
        public CreateRepositories()
        {
            CarRepository = Factories.GetFactory().GetCarRepository();
        }
    }
}
