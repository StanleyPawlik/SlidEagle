using Microsoft.EntityFrameworkCore;
using SlidEagle.Interfaces;
using SlidEagle.Models;
using SlidEagle.Data;

namespace SlidEagle.Repository
{
    public class RideStyleRepository : IRideStyleRepository
    {
        private readonly AppDbContext _context;
        public RideStyleRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }
    }
}
