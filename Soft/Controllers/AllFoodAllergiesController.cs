using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.Soft.Data;
using Mvc.Soft.Models;

namespace Mvc.Soft.Controllers
{
    public class AllFoodAllergiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllFoodAllergiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllFoodAllergies
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllFoodAllergies.ToListAsync());
        }

        // GET: AllFoodAllergies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allFoodAllergies = await _context.AllFoodAllergies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allFoodAllergies == null)
            {
                return NotFound();
            }

            return View(allFoodAllergies);
        }

        // GET: AllFoodAllergies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllFoodAllergies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AllergyName")] AllFoodAllergies allFoodAllergies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allFoodAllergies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allFoodAllergies);
        }

        // GET: AllFoodAllergies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allFoodAllergies = await _context.AllFoodAllergies.FindAsync(id);
            if (allFoodAllergies == null)
            {
                return NotFound();
            }
            return View(allFoodAllergies);
        }

        // POST: AllFoodAllergies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AllergyName")] AllFoodAllergies allFoodAllergies)
        {
            if (id != allFoodAllergies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allFoodAllergies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllFoodAllergiesExists(allFoodAllergies.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(allFoodAllergies);
        }

        // GET: AllFoodAllergies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allFoodAllergies = await _context.AllFoodAllergies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allFoodAllergies == null)
            {
                return NotFound();
            }

            return View(allFoodAllergies);
        }

        // POST: AllFoodAllergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allFoodAllergies = await _context.AllFoodAllergies.FindAsync(id);
            if (allFoodAllergies != null)
            {
                _context.AllFoodAllergies.Remove(allFoodAllergies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllFoodAllergiesExists(int id)
        {
            return _context.AllFoodAllergies.Any(e => e.Id == id);
        }
    }
}
