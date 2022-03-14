#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolExample.Data;
using SchoolExample.Models;

namespace SchoolExample.Controllers
{
    public class StudentRecordsScaffoldedController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentRecordsScaffoldedController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: StudentRecordsScaffolded
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentRecords.Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentRecordsScaffolded/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentRecord = await _context.StudentRecords
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRecord == null)
            {
                return NotFound();
            }

            return View(studentRecord);
        }

        // GET: StudentRecordsScaffolded/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: StudentRecordsScaffolded/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Notes,TotalHours,IsDomestic,UserId")] StudentRecord studentRecord)
        {
            ModelState.ClearValidationState("User");

            ApplicationUser user = await _userManager.FindByIdAsync(studentRecord.UserId);

            studentRecord.User = user;

            if (TryValidateModel(studentRecord))
            {
                _context.Add(studentRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", studentRecord.UserId);
            return View(studentRecord);
        }

        // GET: StudentRecordsScaffolded/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentRecord = await _context.StudentRecords.FindAsync(id);
            if (studentRecord == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", studentRecord.UserId);
            return View(studentRecord);
        }

        // POST: StudentRecordsScaffolded/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Notes,TotalHours,IsDomestic,UserId")] StudentRecord studentRecord)
        {
            if (id != studentRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentRecordExists(studentRecord.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", studentRecord.UserId);
            return View(studentRecord);
        }

        // GET: StudentRecordsScaffolded/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentRecord = await _context.StudentRecords
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentRecord == null)
            {
                return NotFound();
            }

            return View(studentRecord);
        }

        // POST: StudentRecordsScaffolded/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentRecord = await _context.StudentRecords.FindAsync(id);
            _context.StudentRecords.Remove(studentRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentRecordExists(int id)
        {
            return _context.StudentRecords.Any(e => e.Id == id);
        }
    }
}
