using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using SlidEagle.Data;
using SlidEagle.Interfaces;
using SlidEagle.Models;
using SlidEagle.Repository;

namespace SlidEagle.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IItemRepository _repository;
        private readonly IRideStyleRepository _rideStyleRepository;

        public ItemsController(AppDbContext context, IItemRepository repository, IRideStyleRepository rideStyleRepository)
        {
            _context = context;
            _repository = repository;
            _rideStyleRepository = rideStyleRepository;
        }
        

        // GET: Movies
        public async Task<IActionResult> Index(string RideStyle, string searchString)
        {
            // Use LINQ to get list of genres.
            //IQueryable<string> rideStyleQuery = from m in _context.Items
            //                                    orderby m.RideStyle
            //                                    select m.RideStyle;
            //var items = from m in _context.Items
            //            select m;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    items = items.Where(s => s.Name!.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(ItemRideStyle))
            //{
            //    items = items.Where(x => x.RideStyle == ItemRideStyle);
            //}

            //var itemRideStyleVM = new ItemRideStyleViewModel
            //{
            //    RideStyles = new SelectList(await rideStyleQuery.Distinct().ToListAsync()),
            //    Items = await items.ToListAsync()
            //};


            //return View(itemRideStyleVM);

            var items = from m in _repository.Search(searchString, RideStyle)
                         select m;
            //var rideStyles = _rideStyleRepository.GetAll();
            var itemRideStyleVM = new ItemRideStyleViewModel
            {
                RideStyles = new SelectList(_rideStyleRepository.GetName()),
                Items = items.ToList()
            };
            return View(itemRideStyleVM);
            
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            //    var item = await _context.Items
            //        .FirstOrDefaultAsync(m => m.ItemId == id);
            //    if (item == null)
            //    {
            //        return NotFound();
            //    }
            var item = _repository.GetById(id);

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create(string RideStyle)
        {
            var itemRideStyleVM = new ItemRStyleViewModel
            {
                RideStyles = new SelectList(_rideStyleRepository.GetName()),
                Item = new Item()
            };
            return View(itemRideStyleVM);
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Name,RideStyle,Price,Image,Description")] Item item)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(item);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            if (ModelState.IsValid)
            {
                var _item = _repository.Add(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var itemRideStyleVM = new ItemRStyleViewModel
                {
                RideStyles = new SelectList(_rideStyleRepository.GetName()),
                Item = _repository.GetById(id)
            };
            
            if (itemRideStyleVM == null)
            {
                return NotFound();
            }
            return View(itemRideStyleVM);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,RideStyle,Price,Image,Description")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(item);
                
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var _item = _repository.GetById(id);
            if (_item == null)
            {
                return NotFound();
            }

            return View(_item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("ItemId,Name,RideStyle,Price,Image,Description")] Item item)
        {
            _repository.Delete(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
