using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimensionDataSystem.Data;
using DimensionDataSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace DimensionDataSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Manager, Admin, Employee")]
        // GET: Employee
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["NumberSortParm"] = sortOrder == "Age" ? "number_desc" : "Age";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["Getemployeesdetails"] = searchString;

            var employees = from s in _context.Employee select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.EmployeeNumber.ToString().Contains(searchString) || s.Age.ToString().Contains(searchString) ||
                s.Gender.Contains(searchString) || s.MaritalStatus.Contains(searchString) || s.Email.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.MaritalStatus);
                    break;
                case "number_desc":
                    employees = employees.OrderByDescending(s => s.EmployeeNumber);
                    break;
                case "Age":
                    employees = employees.OrderBy(s => s.Age);
                    break;
                default:
                    employees = employees.OrderBy(s => s.Email);
                    break;
            }


            int pageSize = 5;
            return View(await PaginatedList<Employee>.CreatAsync(employees.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        [Authorize(Roles = "Manager, Admin, Employee")]
        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumber,Age,Gender,MaritalStatus,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumber,Age,Gender,MaritalStatus,Email")] Employee employee)
        {
            if (id != employee.EmployeeNumber)
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
                    if (!EmployeeExists(employee.EmployeeNumber))
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
        [Authorize(Roles = "Admin")]
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeNumber == id);
        }
    }
}
