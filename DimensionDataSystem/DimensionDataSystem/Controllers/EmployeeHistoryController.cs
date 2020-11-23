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
    public class EmployeeHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Manager, Admin, Employee")]
        // GET: EmployeeHistory
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var employees = from s in _context.EmployeeHistory select s;

            int pageSize = 5;
            return View(await PaginatedList<EmployeeHistory>.CreatAsync(employees.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        [Authorize(Roles = "Manager, Admin, Employee")]
        // GET: EmployeeHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeHistory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,NumCompaniesWorked,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] EmployeeHistory employeeHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeHistory);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            if (employeeHistory == null)
            {
                return NotFound();
            }
            return View(employeeHistory);
        }

        // POST: EmployeeHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryId,NumCompaniesWorked,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] EmployeeHistory employeeHistory)
        {
            if (id != employeeHistory.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeHistoryExists(employeeHistory.HistoryId))
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
            return View(employeeHistory);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeHistory = await _context.EmployeeHistory
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (employeeHistory == null)
            {
                return NotFound();
            }

            return View(employeeHistory);
        }

        // POST: EmployeeHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeHistory = await _context.EmployeeHistory.FindAsync(id);
            _context.EmployeeHistory.Remove(employeeHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeHistoryExists(int id)
        {
            return _context.EmployeeHistory.Any(e => e.HistoryId == id);
        }
    }
}
