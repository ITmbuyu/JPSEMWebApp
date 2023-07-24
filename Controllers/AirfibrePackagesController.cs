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
    public class AirfibrePackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirfibrePackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AirfibrePackages
        public async Task<IActionResult> Index( int page = 1, int pageSize = 4)
        {
            var totalItems = await _context.AirfibrePackages.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var airfibrePackages = await _context.AirfibrePackages
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginatedAirfibrePackagesViewModel
            {
                AirfibrePackages = airfibrePackages,
                PageNumber = page,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(model);
              //return _context.AirfibrePackages != null ? 
              //            View(await _context.AirfibrePackages.ToListAsync()) :
              //            Problem("Entity set 'ApplicationDbContext.AirfibrePackages'  is null.");
        }

        // GET: AirfibrePackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AirfibrePackages == null)
            {
                return NotFound();
            }

            var airfibrePackage = await _context.AirfibrePackages
                .FirstOrDefaultAsync(m => m.AirfibrePackageId == id);
            if (airfibrePackage == null)
            {
                return NotFound();
            }

            return View(airfibrePackage);
        }

        // GET: AirfibrePackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AirfibrePackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirfibrePackageId,Speed,Description,Capicity,Price,InstallationPrice")] AirfibrePackage airfibrePackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airfibrePackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airfibrePackage);
        }

        // GET: AirfibrePackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AirfibrePackages == null)
            {
                return NotFound();
            }

            var airfibrePackage = await _context.AirfibrePackages.FindAsync(id);
            if (airfibrePackage == null)
            {
                return NotFound();
            }
            return View(airfibrePackage);
        }

        // POST: AirfibrePackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirfibrePackageId,Speed,Description,Capicity,Price,InstallationPrice")] AirfibrePackage airfibrePackage)
        {
            if (id != airfibrePackage.AirfibrePackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airfibrePackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirfibrePackageExists(airfibrePackage.AirfibrePackageId))
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
            return View(airfibrePackage);
        }

        // GET: AirfibrePackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AirfibrePackages == null)
            {
                return NotFound();
            }

            var airfibrePackage = await _context.AirfibrePackages
                .FirstOrDefaultAsync(m => m.AirfibrePackageId == id);
            if (airfibrePackage == null)
            {
                return NotFound();
            }

            return View(airfibrePackage);
        }

        // POST: AirfibrePackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AirfibrePackages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AirfibrePackages'  is null.");
            }
            var airfibrePackage = await _context.AirfibrePackages.FindAsync(id);
            if (airfibrePackage != null)
            {
                _context.AirfibrePackages.Remove(airfibrePackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirfibrePackageExists(int id)
        {
          return (_context.AirfibrePackages?.Any(e => e.AirfibrePackageId == id)).GetValueOrDefault();
        }
    }
}
