using Microsoft.EntityFrameworkCore;
using SlidEagle.Interfaces;
using SlidEagle.Models;
using SlidEagle.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SlidEagle.Repository
{
    public class RideStyleRepository : IRideStyleRepository
    {
        private readonly AppDbContext _context;
        public RideStyleRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(RideStyle rideStyle)
        {
            _context.Add(rideStyle);
            return Save();
        }

        public bool Delete(RideStyle rideStyle)
        {
            _context.Remove(rideStyle);
            return Save();
        }

        public IEnumerable<string> GetName()
        {
            return _context.RideStyles.Select(x => x.Name);
        }

        public RideStyle GetById(int? id)
        {
            return _context.RideStyles.Find(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(RideStyle rideStyle)
        {
            _context.Update(rideStyle);
            return Save();
        }

        public IEnumerable<RideStyle> GetAll()
        {
            return _context.RideStyles.ToList();
        }

        //IEnumerable<RideStyle> IRideStyleRepository.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
