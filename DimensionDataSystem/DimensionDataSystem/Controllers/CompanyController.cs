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
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Manager")]
        // GET: Company
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

            var company = from s in _context.Company select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                company = company.Where(s => s.EmployeeCount.ToString().Contains(searchString) || s.StockOptionLevel.ToString().Contains(searchString) ||
                s.BusinessTravel.Contains(searchString) || s.TotalWorkingYears.ToString().Contains(searchString)
                || s.TrainingTimesLastYear.ToString().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    company = company.OrderByDescending(s => s.BusinessTravel);
                    break;
                case "number_desc":
                    company = company.OrderByDescending(s => s.StockOptionLevel);
                    break;
                case "Age":
                    company = company.OrderBy(s => s.TotalWorkingYears);
                    break;
                default:
                    company = company.OrderBy(s => s.TrainingTimesLastYear);
                    break;
            }


            int pageSize = 5;
            return View(await PaginatedList<Company>.CreatAsync(company.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [Authorize(Roles = "Manager")]
        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [Authorize(Roles = "Manager")]
        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,EmployeeCount,BusinessTravel,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }
        [Authorize(Roles = "Manager")]
        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,EmployeeCount,BusinessTravel,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
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
            return View(company);
        }
        [Authorize(Roles = "Manager")]
        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.CompanyId == id);
        }
    }
}
