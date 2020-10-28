using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmploeesData.Data;
using EmploeesData.Models;

namespace EmploeesData.Controllers
{
    public class Cmpg323Project2DatasetController : Controller
    {
        private readonly DimensionDBContext _context;

        public Cmpg323Project2DatasetController(DimensionDBContext context)
        {
            _context = context;
        }

        // GET: Cmpg323Project2Dataset
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cmpg323Project2Dataset.ToListAsync());
        }

        // GET: Cmpg323Project2Dataset/Details/5
        public async Task<IActionResult> Details(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmpg323Project2Dataset = await _context.Cmpg323Project2Dataset
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (cmpg323Project2Dataset == null)
            {
                return NotFound();
            }

            return View(cmpg323Project2Dataset);
        }

        // GET: Cmpg323Project2Dataset/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cmpg323Project2Dataset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] Cmpg323Project2Dataset cmpg323Project2Dataset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmpg323Project2Dataset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmpg323Project2Dataset);
        }

        // GET: Cmpg323Project2Dataset/Edit/5
        public async Task<IActionResult> Edit(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmpg323Project2Dataset = await _context.Cmpg323Project2Dataset.FindAsync(id);
            if (cmpg323Project2Dataset == null)
            {
                return NotFound();
            }
            return View(cmpg323Project2Dataset);
        }

        // POST: Cmpg323Project2Dataset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(double? id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] Cmpg323Project2Dataset cmpg323Project2Dataset)
        {
            if (id != cmpg323Project2Dataset.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmpg323Project2Dataset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cmpg323Project2DatasetExists(cmpg323Project2Dataset.EmployeeNumber))
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
            return View(cmpg323Project2Dataset);
        }

        // GET: Cmpg323Project2Dataset/Delete/5
        public async Task<IActionResult> Delete(double? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmpg323Project2Dataset = await _context.Cmpg323Project2Dataset
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (cmpg323Project2Dataset == null)
            {
                return NotFound();
            }

            return View(cmpg323Project2Dataset);
        }

        // POST: Cmpg323Project2Dataset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(double? id)
        {
            var cmpg323Project2Dataset = await _context.Cmpg323Project2Dataset.FindAsync(id);
            _context.Cmpg323Project2Dataset.Remove(cmpg323Project2Dataset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cmpg323Project2DatasetExists(double? id)
        {
            return _context.Cmpg323Project2Dataset.Any(e => e.EmployeeNumber == id);
        }
    }
}
