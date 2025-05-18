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
    public class AllFoodAllergiesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index() => View(await _context.AllFoodAllergies.ToListAsync());
        public async Task<IActionResult> Details(int? id)
        {
            var allFoodAllergies = await FindAsync(id);
            return allFoodAllergies == null ? NotFound() : View(allFoodAllergies);
        }
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(AllFoodAllergies allFoodAllergies)
        {
            if (!ModelState.IsValid) return View(allFoodAllergies);
            _context.Add(allFoodAllergies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));            
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var allFoodAllergies = await FindAsync(id);
            return allFoodAllergies == null ? NotFound() : View(allFoodAllergies);
        }
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, AllFoodAllergies allFoodAllergies)
        {
            if (id != allFoodAllergies.Id) return NotFound();
            if (!ModelState.IsValid) return View(allFoodAllergies);
            _context.Update(allFoodAllergies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var allFoodAllergies = await FindAsync(id);
            return allFoodAllergies == null ? NotFound() : View(allFoodAllergies);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allFoodAllergies = await _context.AllFoodAllergies.FindAsync(id);
            if (allFoodAllergies != null) _context.AllFoodAllergies.Remove(allFoodAllergies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<AllFoodAllergies> FindAsync(int? id) => id == null ? null : await _context.AllFoodAllergies.FindAsync(id);
    }
}
