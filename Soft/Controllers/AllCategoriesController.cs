using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers
{
    public class AllCategoriesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index() => View(await _context.AllCategories.ToListAsync());      
        public async Task<IActionResult> Details(int? id)
        {
            var allCategories = await FindAsync(id);
            return allCategories == null ? NotFound() : View(allCategories);
        }
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(AllCategories allCategories)
        {
            if (!ModelState.IsValid) return View(allCategories);            
            _context.Add(allCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var allCategories = await FindAsync(id);
            return allCategories == null ? NotFound() : View(allCategories);
        }
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, AllCategories allCategories)
        {
            if (id != allCategories.Id) return NotFound();
            if (!ModelState.IsValid)
            _context.Update(allCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));            
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var allCategories = await FindAsync(id);
            return allCategories == null ? NotFound() : View(allCategories);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allCategories = await _context.AllCategories.FindAsync(id);
            if (allCategories != null) _context.AllCategories.Remove(allCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<AllCategories> FindAsync(int? id) => id == null ? null : await _context.AllCategories.FindAsync(id);       
    }
}
