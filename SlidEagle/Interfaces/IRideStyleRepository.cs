using SlidEagle.Models;

namespace SlidEagle.Interfaces
{
    public interface IRideStyleRepository
    {
        IEnumerable<string> GetName();
        IEnumerable<RideStyle> GetAll();
        RideStyle GetById(int? id);
        bool Add(RideStyle rideStyle);
        bool Update(RideStyle rideStyle);
        bool Delete(RideStyle rideStyle);
        bool Save();

    }
}