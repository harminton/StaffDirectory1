using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using StaffDirectory.Models;
using StaffDirectory1.Areas.Identity.Data;

namespace StaffDirectory1.Controllers
{
    
    public class StaffsController : Controller
    {
        private readonly StaffContext _context;

        public StaffsController(StaffContext context)
        {
            _context = context;
        }


        // GET: Staffs
        public async Task<IActionResult> Index(string sortorder, string searchString, string CurrentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortorder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortorder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortorder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }

            else
            {
                searchString = CurrentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var staff = from s in _context.Staff
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                staff = staff.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortorder)
            {
                case "name_desc":
                    staff = staff.OrderByDescending(s => s.FirstName);
                    staff = staff.OrderByDescending(s => s.LastName);

                    break;
               
                default:
                    staff = staff.OrderByDescending(s => s.FirstName);
                    staff = staff.OrderByDescending(s => s.LastName);
                    break;
            }

            // return _context.Students != null ?
            //       View(await _context.Students.ToListAsync()):
            //        Problem("Entity set 'StaffContext.Students'  is null.");

            int pageSize = 3;
            return View(await PageInatedList<Staff>.CreateAsync(staff.AsNoTracking(), pageNumber ?? 1, pageSize));
        }




        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,FirstName,LastName,StaffStatuse,TeacherCode,HomeRoom")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,FirstName,LastName,StaffStatuse,TeacherCode,HomeRoom")] Staff staff)
        {
            if (id != staff.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffID))
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
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Staff == null)
            {
                return Problem("Entity set 'StaffContext.Staff'  is null.");
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return (_context.Staff?.Any(e => e.StaffID == id)).GetValueOrDefault();
        }





    }
}
