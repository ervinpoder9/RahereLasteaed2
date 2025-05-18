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
    public class ChildrenController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<IActionResult> Index() => View(await _context.Children.ToListAsync());      
        public async Task<IActionResult> Details(int? id)
        {
            var children = await FindAsync(id);
            return children == null ? NotFound() : View(children);
        }        
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Create(Children children)
        {
            if (!ModelState.IsValid) return View(children);
            _context.Add(children);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var children = await FindAsync(id);
            return children == null ? NotFound() : View(children);
        }
        [HttpPost, ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id, Children children)
        {
            if (id != children.Id) return NotFound();
            if (! ModelState.IsValid) return View(children);
            _context.Update(children);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));         
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var children = await FindAsync(id);
            return children == null ? NotFound() : View(children);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var children = await _context.Children.FindAsync(id);
            if (children != null) _context.Children.Remove(children);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<Children> FindAsync(int? id) => id == null ? null : await _context.Children.FindAsync(id);
    }
}
