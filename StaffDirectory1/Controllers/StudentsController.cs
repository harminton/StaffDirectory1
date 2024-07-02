using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StaffDirectory.Models;
using StaffDirectory1.Areas.Identity.Data;

namespace StaffDirectory1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StaffContext _context;

        public StudentsController(StaffContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortorder, string searchString, string CurrentFilter, int pageNumber)
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
            var Student = from s in _context.Students
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Student = Student.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortorder)
            {
                case "name_desc":
                    Student = Student.OrderByDescending(s => s.FirstName);
                    Student = Student.OrderByDescending(s => s.LastName);

                    break;
                case "Date":
                    Student = Student.OrderByDescending(s => s.Enrollment);
                    break;
                case "date_desc":
                    Student = Student.OrderByDescending(s => s.Enrollment);
                    break;
                default:
                    Student = Student.OrderByDescending(s => s.FirstName);
                    Student = Student.OrderByDescending(s => s.LastName);
                    break;

              
            }
            int pageSize = 3;
            return _context.Students != null ?
                        View(await _context.Students.ToListAsync()):
                          Problem("Entity set 'StaffContext.Students'  is null.");

          //  int pageSize = 3;
         // return View(await PageInatedList<Students>.CreateAsync(Student.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,FirstName,LastName,AcNumber,HomeRoom,Enrollment")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,FirstName,LastName,AcNumber,HomeRoom,Enrollment")] Students students)
        {
            if (id != students.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.StudentID))
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
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'StaffContext.Students'  is null.");
            }
            var students = await _context.Students.FindAsync(id);
            if (students != null)
            {
                _context.Students.Remove(students);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
          return (_context.Students?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
