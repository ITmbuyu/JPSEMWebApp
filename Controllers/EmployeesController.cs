using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JPSEMWebApp.Data;
using JPSEMWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JPSEMWebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;


        public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> SignInManager, RoleManager<IdentityRole> RoleManager)
        {
            _context = context;
            this.UserManager= UserManager;
            this.SignInManager= SignInManager;
            this.RoleManager= RoleManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
              return _context.Employees != null ? 
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            ViewBag.Roles = list;
            //var user = CreateUser();

            //await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
            //var result = await _userManager.CreateAsync(user, Input.Password);
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmpName,EmpSurname,EmpEmail,EmpPassword,EmployeeRole")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = employee.EmpEmail,
                    Email = employee.EmpEmail
                };

                var result = await UserManager.CreateAsync(user, employee.EmpPassword);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user, employee.EmployeeRole);


                    _context.Add(employee);
                    await _context.SaveChangesAsync();

                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // If creation of the user account fails, add model errors for the failed identity validation errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(employee);
        }



        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,EmpName,EmpSurname,EmpEmail,EmpPassword,EmployeeRole")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
