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
    public class BusinessPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessPackages
        public async Task<IActionResult> Index(int page = 1, int pageSize = 4)
        {
            var totalItems = await _context.BusinessPackages.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var businessPackages = await _context.BusinessPackages
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var model = new PaginatedBusinessPackagesViewModel
            {
                BusinessPackages = businessPackages,
                PageNumber = page,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return View(model);
        }


        // GET: BusinessPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessPackages == null)
            {
                return NotFound();
            }

            var businessPackage = await _context.BusinessPackages
                .FirstOrDefaultAsync(m => m.BusinessPackageId == id);
            if (businessPackage == null)
            {
                return NotFound();
            }

            return View(businessPackage);
        }

        // GET: BusinessPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessPackageId,Speed,Description,Capacity,Price,RedundancyPrice,InstallationPrice")] BusinessPackage businessPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessPackage);
        }

        // GET: BusinessPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessPackages == null)
            {
                return NotFound();
            }

            var businessPackage = await _context.BusinessPackages.FindAsync(id);
            if (businessPackage == null)
            {
                return NotFound();
            }
            return View(businessPackage);
        }

        // POST: BusinessPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessPackageId,Speed,Description,Capacity,Price,RedundancyPrice,InstallationPrice")] BusinessPackage businessPackage)
        {
            if (id != businessPackage.BusinessPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessPackageExists(businessPackage.BusinessPackageId))
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
            return View(businessPackage);
        }

        // GET: BusinessPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessPackages == null)
            {
                return NotFound();
            }

            var businessPackage = await _context.BusinessPackages
                .FirstOrDefaultAsync(m => m.BusinessPackageId == id);
            if (businessPackage == null)
            {
                return NotFound();
            }

            return View(businessPackage);
        }

        // POST: BusinessPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessPackages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BusinessPackages'  is null.");
            }
            var businessPackage = await _context.BusinessPackages.FindAsync(id);
            if (businessPackage != null)
            {
                _context.BusinessPackages.Remove(businessPackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessPackageExists(int id)
        {
          return (_context.BusinessPackages?.Any(e => e.BusinessPackageId == id)).GetValueOrDefault();
        }
    }
}
