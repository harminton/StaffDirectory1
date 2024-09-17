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
    
    public class PersonalInformationsController : Controller
    {
        private readonly StaffContext _context;

        public PersonalInformationsController(StaffContext context)
        {
            _context = context;
        }

        // GET: PersonalInformations
        public async Task<IActionResult> Index()
        {
            var staffContext = _context.PersonalInformation.Include(p => p.Staff).Include(p => p.Student);
            return View(await staffContext.ToListAsync());
        }

        // GET: PersonalInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonalInformation == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformation
                .Include(p => p.Staff)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.InformationID == id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            return View(personalInformation);
        }

        // GET: PersonalInformations/Create
        public IActionResult Create()
        {
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID");
            ViewData["Studentid"] = new SelectList(_context.Students, "StudentID", "AcNumber");
            return View();
        }

        // POST: PersonalInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InformationID,Staffid,Studentid,FirstName,Lastname,Phone,Email,HomeAddress")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", personalInformation.Staffid);
            ViewData["Studentid"] = new SelectList(_context.Students, "StudentID", "AcNumber", personalInformation.Studentid);
            return View(personalInformation);
        }

        // GET: PersonalInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonalInformation == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformation.FindAsync(id);
            if (personalInformation == null)
            {
                return NotFound();
            }
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", personalInformation.Staffid);
            ViewData["Studentid"] = new SelectList(_context.Students, "StudentID", "AcNumber", personalInformation.Studentid);
            return View(personalInformation);
        }

        // POST: PersonalInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InformationID,Staffid,Studentid,FirstName,Lastname,Phone,Email,HomeAddress")] PersonalInformation personalInformation)
        {
            if (id != personalInformation.InformationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInformationExists(personalInformation.InformationID))
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
            ViewData["Staffid"] = new SelectList(_context.Staff, "StaffID", "StaffID", personalInformation.Staffid);
            ViewData["Studentid"] = new SelectList(_context.Students, "StudentID", "AcNumber", personalInformation.Studentid);
            return View(personalInformation);
        }

        // GET: PersonalInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonalInformation == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformation
                .Include(p => p.Staff)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.InformationID == id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            return View(personalInformation);
        }

        // POST: PersonalInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonalInformation == null)
            {
                return Problem("Entity set 'StaffContext.PersonalInformation'  is null.");
            }
            var personalInformation = await _context.PersonalInformation.FindAsync(id);
            if (personalInformation != null)
            {
                _context.PersonalInformation.Remove(personalInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInformationExists(int id)
        {
          return (_context.PersonalInformation?.Any(e => e.InformationID == id)).GetValueOrDefault();
        }
    }
}
