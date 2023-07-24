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
    public class RoutersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Routers
        public async Task<IActionResult> Index()
        {
              return _context.Routers != null ? 
                          View(await _context.Routers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Routers'  is null.");
        }

        // GET: Routers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Routers == null)
            {
                return NotFound();
            }

            var router = await _context.Routers
                .FirstOrDefaultAsync(m => m.RouterId == id);
            if (router == null)
            {
                return NotFound();
            }

            return View(router);
        }

        // GET: Routers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouterId,Description,Price,OnceOffPrice")] Router router)
        {
            if (ModelState.IsValid)
            {
                _context.Add(router);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(router);
        }

        // GET: Routers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Routers == null)
            {
                return NotFound();
            }

            var router = await _context.Routers.FindAsync(id);
            if (router == null)
            {
                return NotFound();
            }
            return View(router);
        }

        // POST: Routers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouterId,Description,Price,OnceOffPrice")] Router router)
        {
            if (id != router.RouterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(router);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouterExists(router.RouterId))
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
            return View(router);
        }

        // GET: Routers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Routers == null)
            {
                return NotFound();
            }

            var router = await _context.Routers
                .FirstOrDefaultAsync(m => m.RouterId == id);
            if (router == null)
            {
                return NotFound();
            }

            return View(router);
        }

        // POST: Routers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Routers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Routers'  is null.");
            }
            var router = await _context.Routers.FindAsync(id);
            if (router != null)
            {
                _context.Routers.Remove(router);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouterExists(int id)
        {
          return (_context.Routers?.Any(e => e.RouterId == id)).GetValueOrDefault();
        }
    }
}
