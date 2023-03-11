using SlidEagle.Models;

namespace SlidEagle.Interfaces
{
    public interface IRideStyleRepository
    {
        IEnumerable<Item> GetAll();
    }
}