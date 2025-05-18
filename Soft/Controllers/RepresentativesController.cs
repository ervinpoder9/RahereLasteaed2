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
    public class RepresentativesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index() => View(await _context.Representative.ToListAsync());        
        public async Task<IActionResult> Details(int? id)
        {
            var representative = await FindAsync(id);
            return representative == null ? NotFound() : View(representative);
        }
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(Representative representative)
        {
            if (!ModelState.IsValid) return View(representative);
            _context.Add(representative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));           
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var representative = await FindAsync(id);
            return representative == null ? NotFound() : View(representative);
        }
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, Representative representative)
        {
            if (id != representative.Id) return NotFound();
            if (!ModelState.IsValid) return View(representative);
            _context.Update(representative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var representative = await FindAsync(id);
            return representative == null ? NotFound() : View(representative);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var representative = await _context.Representative.FindAsync(id);
            if (representative != null) _context.Representative.Remove(representative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<Representative> FindAsync(int? id) => id == null ? null : await _context.Representative.FindAsync(id);
    }
}
