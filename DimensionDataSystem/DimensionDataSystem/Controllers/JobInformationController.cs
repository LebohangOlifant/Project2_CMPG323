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
    public class JobInformationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobInformationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobInformation
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobInformation.ToListAsync());
        }

        // GET: JobInformation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInformation = await _context.JobInformation
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobInformation == null)
            {
                return NotFound();
            }

            return View(jobInformation);
        }

        // GET: JobInformation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,Department,JobInvolvement,JobLevel,JobRole")] JobInformation jobInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobInformation);
        }

        // GET: JobInformation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInformation = await _context.JobInformation.FindAsync(id);
            if (jobInformation == null)
            {
                return NotFound();
            }
            return View(jobInformation);
        }

        // POST: JobInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,Department,JobInvolvement,JobLevel,JobRole")] JobInformation jobInformation)
        {
            if (id != jobInformation.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobInformationExists(jobInformation.JobId))
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
            return View(jobInformation);
        }

        // GET: JobInformation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInformation = await _context.JobInformation
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobInformation == null)
            {
                return NotFound();
            }

            return View(jobInformation);
        }

        // POST: JobInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobInformation = await _context.JobInformation.FindAsync(id);
            _context.JobInformation.Remove(jobInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobInformationExists(int id)
        {
            return _context.JobInformation.Any(e => e.JobId == id);
        }
    }
}
