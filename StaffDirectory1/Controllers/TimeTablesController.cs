using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffDirectory.Models;
using StaffDirectory1.Areas.Identity.Data;

namespace StaffDirectory1.Controllers
{
    [Authorize]

    public class TimeTablesController : Controller
    {
        private readonly StaffContext _context;

        public TimeTablesController(StaffContext context)
        {
            _context = context;
        }

        // GET: TimeTables
        public async Task<IActionResult> Index()
        {
            var staffContext = _context.TimeTable.Include(t => t.Staff).Include(t => t.Student);
            return View(await staffContext.ToListAsync());
        }

        // GET: TimeTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeTable == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTable
                .Include(t => t.Staff)
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.TimeTableID == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // GET: TimeTables/Create
        public IActionResult Create()
        {
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID");
            ViewData["Studentid"] = new SelectList(_context.Set<Students>(), "StudentID", "AcNumber");
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeTableID,Staffid,Studentid,FirstPeriod,SecondPeriod,ThirdPeriod,FourthPeriod,FifthPeriod")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", timeTable.Staffid);
            ViewData["Studentid"] = new SelectList(_context.Set<Students>(), "StudentID", "AcNumber", timeTable.Studentid);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeTable == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTable.FindAsync(id);
            if (timeTable == null)
            {
                return NotFound();
            }
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", timeTable.Staffid);
            ViewData["Studentid"] = new SelectList(_context.Set<Students>(), "StudentID", "AcNumber", timeTable.Studentid);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeTableID,Staffid,Studentid,FirstPeriod,SecondPeriod,ThirdPeriod,FourthPeriod,FifthPeriod")] TimeTable timeTable)
        {
            if (id != timeTable.TimeTableID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTableExists(timeTable.TimeTableID))
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
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", timeTable.Staffid);
            ViewData["Studentid"] = new SelectList(_context.Set<Students>(), "StudentID", "AcNumber", timeTable.Studentid);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeTable == null)
            {
                return NotFound();
            }

            var timeTable = await _context.TimeTable
                .Include(t => t.Staff)
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.TimeTableID == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeTable == null)
            {
                return Problem("Entity set 'StaffContext.TimeTable'  is null.");
            }
            var timeTable = await _context.TimeTable.FindAsync(id);
            if (timeTable != null)
            {
                _context.TimeTable.Remove(timeTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeTableExists(int id)
        {
          return (_context.TimeTable?.Any(e => e.TimeTableID == id)).GetValueOrDefault();
        }
    }
}
