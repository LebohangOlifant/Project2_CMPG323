using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimensionDataSystem.Data;
using DimensionDataSystem.Models;

namespace DimensionDataSystem.Controllers
{
    public class CompanyCostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyCostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompanyCost
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyCost.ToListAsync());
        }

        // GET: CompanyCost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyCost = await _context.CompanyCost
                .FirstOrDefaultAsync(m => m.CostId == id);
            if (companyCost == null)
            {
                return NotFound();
            }

            return View(companyCost);
        }

        // GET: CompanyCost/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyCost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CostId,DailyRate,HourlyRate,MonthlyIncome,MonthlyRate,PercentSalaryHike,StandardHours")] CompanyCost companyCost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyCost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyCost);
        }

        // GET: CompanyCost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyCost = await _context.CompanyCost.FindAsync(id);
            if (companyCost == null)
            {
                return NotFound();
            }
            return View(companyCost);
        }

        // POST: CompanyCost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CostId,DailyRate,HourlyRate,MonthlyIncome,MonthlyRate,PercentSalaryHike,StandardHours")] CompanyCost companyCost)
        {
            if (id != companyCost.CostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyCost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyCostExists(companyCost.CostId))
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
            return View(companyCost);
        }

        // GET: CompanyCost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyCost = await _context.CompanyCost
                .FirstOrDefaultAsync(m => m.CostId == id);
            if (companyCost == null)
            {
                return NotFound();
            }

            return View(companyCost);
        }

        // POST: CompanyCost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyCost = await _context.CompanyCost.FindAsync(id);
            _context.CompanyCost.Remove(companyCost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyCostExists(int id)
        {
            return _context.CompanyCost.Any(e => e.CostId == id);
        }
    }
}
