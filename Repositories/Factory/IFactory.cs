using Repositories.Abstract;

namespace Repositories.Factory
{
    public interface IFactory
    {
        ICarRepository GetCarRepository();
    }
}
