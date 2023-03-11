using SlidEagle.Models;

namespace SlidEagle.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Item GetById(int id);
        bool Add(Item item);
        bool Update(Item item);
        bool Delete(Item item);
        bool DeleteAll();
        bool Save();
    }
}
