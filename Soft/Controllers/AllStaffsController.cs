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
    public class AllStaffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllStaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllStaffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllStaff.ToListAsync());
        }

        // GET: AllStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allStaff = await _context.AllStaff
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allStaff == null)
            {
                return NotFound();
            }

            return View(allStaff);
        }

        // GET: AllStaffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("position,education,Id,Name,Surname,IDNumber,Address,Mobile,Email,AdditionalInfo")] AllStaff allStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allStaff);
        }

        // GET: AllStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allStaff = await _context.AllStaff.FindAsync(id);
            if (allStaff == null)
            {
                return NotFound();
            }
            return View(allStaff);
        }

        // POST: AllStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("position,education,Id,Name,Surname,IDNumber,Address,Mobile,Email,AdditionalInfo")] AllStaff allStaff)
        {
            if (id != allStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllStaffExists(allStaff.Id))
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
            return View(allStaff);
        }

        // GET: AllStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allStaff = await _context.AllStaff
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allStaff == null)
            {
                return NotFound();
            }

            return View(allStaff);
        }

        // POST: AllStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allStaff = await _context.AllStaff.FindAsync(id);
            if (allStaff != null)
            {
                _context.AllStaff.Remove(allStaff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllStaffExists(int id)
        {
            return _context.AllStaff.Any(e => e.Id == id);
        }
    }
}
