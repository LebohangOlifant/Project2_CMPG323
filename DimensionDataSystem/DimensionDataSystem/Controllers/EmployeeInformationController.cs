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
    public class EmployeeInformationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeInformationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Manager, Admin, Employee")]
        // GET: EmployeeInformation
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeInformation.ToListAsync());
        }
        [Authorize(Roles = "Manager, Admin, Employee")]
        // GET: EmployeeInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await _context.EmployeeInformation
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeInformation == null)
            {
                return NotFound();
            }

            return View(employeeInformation);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeInformation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Attrition,DistanceFromHome,Education,EducationField,Over18,OverTime,WorkLifeBalance")] EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeInformation);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await _context.EmployeeInformation.FindAsync(id);
            if (employeeInformation == null)
            {
                return NotFound();
            }
            return View(employeeInformation);
        }

        // POST: EmployeeInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Attrition,DistanceFromHome,Education,EducationField,Over18,OverTime,WorkLifeBalance")] EmployeeInformation employeeInformation)
        {
            if (id != employeeInformation.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeInformationExists(employeeInformation.EmployeeId))
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
            return View(employeeInformation);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInformation = await _context.EmployeeInformation
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeInformation == null)
            {
                return NotFound();
            }

            return View(employeeInformation);
        }

        // POST: EmployeeInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeInformation = await _context.EmployeeInformation.FindAsync(id);
            _context.EmployeeInformation.Remove(employeeInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeInformationExists(int id)
        {
            return _context.EmployeeInformation.Any(e => e.EmployeeId == id);
        }
    }
}
