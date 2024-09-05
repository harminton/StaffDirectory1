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
    public class DepartmentStaffsController : Controller
    {
        private readonly StaffContext _context;

        public DepartmentStaffsController(StaffContext context)
        {
            _context = context;
        }

        // GET: DepartmentStaffs
        public async Task<IActionResult> Index()
        {
            var staffContext = _context.DepartmentStaff.Include(d => d.Staff);
            return View(await staffContext.ToListAsync());
        }

        // GET: DepartmentStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentStaff == null)
            {
                return NotFound();
            }

            var departmentStaff = await _context.DepartmentStaff
                .Include(d => d.Staff)
                .FirstOrDefaultAsync(m => m.DepartmentStaffID == id);
            if (departmentStaff == null)
            {
                return NotFound();
            }

            return View(departmentStaff);
        }

        // GET: DepartmentStaffs/Create
        public IActionResult Create()
        {
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID");
            return View();
        }

        // POST: DepartmentStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentStaffID,Departmentid,Staffid")] DepartmentStaff departmentStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", departmentStaff.Staffid);
            return View(departmentStaff);
        }

        // GET: DepartmentStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentStaff == null)
            {
                return NotFound();
            }

            var departmentStaff = await _context.DepartmentStaff.FindAsync(id);
            if (departmentStaff == null)
            {
                return NotFound();
            }
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", departmentStaff.Staffid);
            return View(departmentStaff);
        }

        // POST: DepartmentStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentStaffID,Departmentid,Staffid")] DepartmentStaff departmentStaff)
        {
            if (id != departmentStaff.DepartmentStaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentStaffExists(departmentStaff.DepartmentStaffID))
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
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", departmentStaff.Staffid);
            return View(departmentStaff);
        }

        // GET: DepartmentStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentStaff == null)
            {
                return NotFound();
            }

            var departmentStaff = await _context.DepartmentStaff
                .Include(d => d.Staff)
                .FirstOrDefaultAsync(m => m.DepartmentStaffID == id);
            if (departmentStaff == null)
            {
                return NotFound();
            }

            return View(departmentStaff);
        }

        // POST: DepartmentStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentStaff == null)
            {
                return Problem("Entity set 'StaffContext.DepartmentStaff'  is null.");
            }
            var departmentStaff = await _context.DepartmentStaff.FindAsync(id);
            if (departmentStaff != null)
            {
                _context.DepartmentStaff.Remove(departmentStaff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentStaffExists(int id)
        {
          return (_context.DepartmentStaff?.Any(e => e.DepartmentStaffID == id)).GetValueOrDefault();
        }
    }
}
