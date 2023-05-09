using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkMappingAndDatabase.Data;
using EntityFrameworkMappingAndDatabase.Models;

namespace EntityFrameworkMappingAndDatabase.Controllers
{
    public class PassportsController : Controller
    {
        private readonly MyDbContext _context;

        public PassportsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Passports
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Passports.Include(p => p.Person);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Passports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passports == null)
            {
                return NotFound();
            }

            var passport = await _context.Passports
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PassportId == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // GET: Passports/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "Name");
            return View();
        }

        // POST: Passports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassportId,Number,PersonId")] Passport passport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", passport.PersonId);
            return View(passport);
        }

        // GET: Passports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passports == null)
            {
                return NotFound();
            }

            var passport = await _context.Passports.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", passport.PersonId);
            return View(passport);
        }

        // POST: Passports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PassportId,Number,PersonId")] Passport passport)
        {
            if (id != passport.PassportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassportExists(passport.PassportId))
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
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "PersonId", passport.PersonId);
            return View(passport);
        }

        // GET: Passports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passports == null)
            {
                return NotFound();
            }

            var passport = await _context.Passports
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.PassportId == id);
            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // POST: Passports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passports == null)
            {
                return Problem("Entity set 'MyDbContext.Passports'  is null.");
            }
            var passport = await _context.Passports.FindAsync(id);
            if (passport != null)
            {
                _context.Passports.Remove(passport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassportExists(int id)
        {
          return (_context.Passports?.Any(e => e.PassportId == id)).GetValueOrDefault();
        }
    }
}
