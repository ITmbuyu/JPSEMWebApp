using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JPSEMWebApp.Data;
using JPSEMWebApp.Models;
using JPSEMWebApp.ViewModels;

namespace JPSEMWebApp.Controllers
{
    public class HouseholdPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseholdPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseholdPackages
        public async Task<IActionResult> Index( int page = 1, int pageSize = 4)
        {
            var totalItems = await _context.HouseholdPackages.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var householdPackages = await _context.HouseholdPackages
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginatedHouseHoldViewModel
            {
                HouseholdPackages = householdPackages,
                PageNumber = page,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(model);

              //return _context.HouseholdPackages != null ? 
              //            View(await _context.HouseholdPackages.ToListAsync()) :
              //            Problem("Entity set 'ApplicationDbContext.HouseholdPackages'  is null.");
        }

        // GET: HouseholdPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HouseholdPackages == null)
            {
                return NotFound();
            }

            var householdPackage = await _context.HouseholdPackages
                .FirstOrDefaultAsync(m => m.HouseholdPackageId == id);
            if (householdPackage == null)
            {
                return NotFound();
            }

            return View(householdPackage);
        }

        // GET: HouseholdPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseholdPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HouseholdPackageId,Speed,Description,Capacity,Price")] HouseholdPackage householdPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(householdPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(householdPackage);
        }

        // GET: HouseholdPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HouseholdPackages == null)
            {
                return NotFound();
            }

            var householdPackage = await _context.HouseholdPackages.FindAsync(id);
            if (householdPackage == null)
            {
                return NotFound();
            }
            return View(householdPackage);
        }

        // POST: HouseholdPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HouseholdPackageId,Speed,Description,Capacity,Price")] HouseholdPackage householdPackage)
        {
            if (id != householdPackage.HouseholdPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(householdPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseholdPackageExists(householdPackage.HouseholdPackageId))
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
            return View(householdPackage);
        }

        // GET: HouseholdPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HouseholdPackages == null)
            {
                return NotFound();
            }

            var householdPackage = await _context.HouseholdPackages
                .FirstOrDefaultAsync(m => m.HouseholdPackageId == id);
            if (householdPackage == null)
            {
                return NotFound();
            }

            return View(householdPackage);
        }

        // POST: HouseholdPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HouseholdPackages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HouseholdPackages'  is null.");
            }
            var householdPackage = await _context.HouseholdPackages.FindAsync(id);
            if (householdPackage != null)
            {
                _context.HouseholdPackages.Remove(householdPackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseholdPackageExists(int id)
        {
          return (_context.HouseholdPackages?.Any(e => e.HouseholdPackageId == id)).GetValueOrDefault();
        }
    }
}
