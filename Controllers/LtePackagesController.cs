using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JPSEMWebApp.Data;
using JPSEMWebApp.Models;

namespace JPSEMWebApp.Controllers
{
    public class LtePackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LtePackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LtePackages
        public async Task<IActionResult> Index()
        {
              return _context.LtePackages != null ? 
                          View(await _context.LtePackages.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LtePackages'  is null.");
        }

        // GET: LtePackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LtePackages == null)
            {
                return NotFound();
            }

            var ltePackage = await _context.LtePackages
                .FirstOrDefaultAsync(m => m.LtePackageId == id);
            if (ltePackage == null)
            {
                return NotFound();
            }

            return View(ltePackage);
        }

        // GET: LtePackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LtePackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LtePackageId,Speed,Description,Capacity,Price,InstallationPrice")] LtePackage ltePackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ltePackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ltePackage);
        }

        // GET: LtePackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LtePackages == null)
            {
                return NotFound();
            }

            var ltePackage = await _context.LtePackages.FindAsync(id);
            if (ltePackage == null)
            {
                return NotFound();
            }
            return View(ltePackage);
        }

        // POST: LtePackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LtePackageId,Speed,Description,Capacity,Price,InstallationPrice")] LtePackage ltePackage)
        {
            if (id != ltePackage.LtePackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ltePackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LtePackageExists(ltePackage.LtePackageId))
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
            return View(ltePackage);
        }

        // GET: LtePackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LtePackages == null)
            {
                return NotFound();
            }

            var ltePackage = await _context.LtePackages
                .FirstOrDefaultAsync(m => m.LtePackageId == id);
            if (ltePackage == null)
            {
                return NotFound();
            }

            return View(ltePackage);
        }

        // POST: LtePackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LtePackages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LtePackages'  is null.");
            }
            var ltePackage = await _context.LtePackages.FindAsync(id);
            if (ltePackage != null)
            {
                _context.LtePackages.Remove(ltePackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LtePackageExists(int id)
        {
          return (_context.LtePackages?.Any(e => e.LtePackageId == id)).GetValueOrDefault();
        }
    }
}
