using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using SlidEagle.Data;
using SlidEagle.Interfaces;
using SlidEagle.Models;

namespace SlidEagle.Controllers
{
    public class RideStylesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IRideStyleRepository _rideStyleRepository;

        public RideStylesController(AppDbContext context, IRideStyleRepository rideStyleRepository)
        {
            _context = context;
            _rideStyleRepository = rideStyleRepository;
        }

        // GET: RideStyles
        public async Task<IActionResult> Index()
        {
              return View(_rideStyleRepository.GetAll());
        }

        // GET: RideStyles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rideStyle = _rideStyleRepository.GetById(id);
            if (rideStyle == null)
            {
                return NotFound();
            }

            return View(rideStyle);
        }

        // GET: RideStyles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RideStyles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RideStyleId,Name")] RideStyle rideStyle)
        {
            if (ModelState.IsValid)
            {
                _rideStyleRepository.Add(rideStyle);
                return RedirectToAction(nameof(Index));
            }
            return View(rideStyle);
        }

        // GET: RideStyles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rideStyle = _rideStyleRepository.GetById(id);
            if (rideStyle == null)
            {
                return NotFound();
            }
            return View(rideStyle);
        }

        // POST: RideStyles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RideStyleId,Name")] RideStyle rideStyle)
        {
            if (id != rideStyle.RideStyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _rideStyleRepository.Update(rideStyle);
                return RedirectToAction(nameof(Index));
            }
            return View(rideStyle);
        }

        // GET: RideStyles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rideStyle = _rideStyleRepository.GetById(id);
            if (rideStyle == null)
            {
                return NotFound();
            }

            return View(rideStyle);
        }

        // POST: RideStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("RideStyleId,Name")] RideStyle rideStyle)
        {
            _rideStyleRepository.Delete(rideStyle);
            return RedirectToAction(nameof(Index));
        }

        //private bool RideStyleExists(int id)
        //{
        //  return _context.RideStyles.Any(e => e.RideStyleId == id);
        //}
    }
}
