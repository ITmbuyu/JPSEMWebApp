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
    public class ServiceNoticesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiceNoticesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceNotices
        public async Task<IActionResult> Index()
        {
              return _context.ServiceNotices != null ? 
                          View(await _context.ServiceNotices.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ServiceNotices'  is null.");
        }

        // GET: ServiceNotices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceNotices == null)
            {
                return NotFound();
            }

            var serviceNotice = await _context.ServiceNotices
                .FirstOrDefaultAsync(m => m.ServiceNoticeId == id);
            if (serviceNotice == null)
            {
                return NotFound();
            }

            return View(serviceNotice);
        }

        // GET: ServiceNotices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceNotices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceNoticeId,Message")] ServiceNotice serviceNotice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceNotice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceNotice);
        }

        // GET: ServiceNotices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceNotices == null)
            {
                return NotFound();
            }

            var serviceNotice = await _context.ServiceNotices.FindAsync(id);
            if (serviceNotice == null)
            {
                return NotFound();
            }
            return View(serviceNotice);
        }

        // POST: ServiceNotices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceNoticeId,Message")] ServiceNotice serviceNotice)
        {
            if (id != serviceNotice.ServiceNoticeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceNotice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceNoticeExists(serviceNotice.ServiceNoticeId))
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
            return View(serviceNotice);
        }

        // GET: ServiceNotices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceNotices == null)
            {
                return NotFound();
            }

            var serviceNotice = await _context.ServiceNotices
                .FirstOrDefaultAsync(m => m.ServiceNoticeId == id);
            if (serviceNotice == null)
            {
                return NotFound();
            }

            return View(serviceNotice);
        }

        // POST: ServiceNotices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceNotices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ServiceNotices'  is null.");
            }
            var serviceNotice = await _context.ServiceNotices.FindAsync(id);
            if (serviceNotice != null)
            {
                _context.ServiceNotices.Remove(serviceNotice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceNoticeExists(int id)
        {
          return (_context.ServiceNotices?.Any(e => e.ServiceNoticeId == id)).GetValueOrDefault();
        }
    }
}
