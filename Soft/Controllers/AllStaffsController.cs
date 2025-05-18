using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc.Domain;
using Mvc.Soft.Data;

namespace Mvc.Soft.Controllers
{
    public class AllStaffsController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index() => View(await _context.AllStaff.ToListAsync());
        public async Task<IActionResult> Details(int? id)
        {
            var allStaff = await FindAsync(id);
            return allStaff == null ? NotFound() : View(allStaff);
        }
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(AllStaff allStaff)
        {
            if (!ModelState.IsValid) return View(allStaff);
            _context.Add(allStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var allStaff = await FindAsync(id);
            return allStaff == null ? NotFound() : View(allStaff);
        }
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, AllStaff allStaff)
        {
            if (id != allStaff.Id) return NotFound();
            if (!ModelState.IsValid) return View(allStaff);
            _context.Update(allStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));           
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var allStaff = await FindAsync(id);
            return allStaff == null ? NotFound() : View(allStaff);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allStaff = await _context.AllStaff.FindAsync(id);
            if (allStaff != null) _context.AllStaff.Remove(allStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<AllStaff> FindAsync(int? id) => id == null ? null : await _context.AllStaff.FindAsync(id);
    }
}
