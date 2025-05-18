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
    public class AllCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllCategories.ToListAsync());
        }

        // GET: AllCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allCategories = await _context.AllCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allCategories == null)
            {
                return NotFound();
            }

            return View(allCategories);
        }

        // GET: AllCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] AllCategories allCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allCategories);
        }

        // GET: AllCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allCategories = await _context.AllCategories.FindAsync(id);
            if (allCategories == null)
            {
                return NotFound();
            }
            return View(allCategories);
        }

        // POST: AllCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName")] AllCategories allCategories)
        {
            if (id != allCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllCategoriesExists(allCategories.Id))
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
            return View(allCategories);
        }

        // GET: AllCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allCategories = await _context.AllCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allCategories == null)
            {
                return NotFound();
            }

            return View(allCategories);
        }

        // POST: AllCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allCategories = await _context.AllCategories.FindAsync(id);
            if (allCategories != null)
            {
                _context.AllCategories.Remove(allCategories);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllCategoriesExists(int id)
        {
            return _context.AllCategories.Any(e => e.Id == id);
        }
    }
}
