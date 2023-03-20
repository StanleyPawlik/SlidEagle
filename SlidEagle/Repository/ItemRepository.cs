using Microsoft.EntityFrameworkCore;
using SlidEagle.Data;
using SlidEagle.Interfaces;
using SlidEagle.Models;

namespace SlidEagle.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(Item item)
        {
            _context.Add(item);
            return Save();
        }

        public bool Delete(Item item)
        {
            _context.Remove(item);
            return Save();
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item GetById(int? id)
        {
            return _context.Items.Find(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public IEnumerable<Item> Search(string searchString, string ItemRideStyle)
        {
            IQueryable<string> rideStyleQuery = from m in _context.Items
                                                orderby m.RideStyle
                                                select m.RideStyle;
            var items = from m in _context.Items
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(ItemRideStyle))
            {
                items = items.Where(x => x.RideStyle == ItemRideStyle);
            }


            return items.ToList() ;
        }

        public bool Update(Item item)
        {
            _context.Update(item);
            return Save();
        }
    }
}
