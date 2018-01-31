using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class SmesController : Controller
    {
        private readonly ClubContext _context;

        public SmesController(ClubContext context)
        {
            _context = context;
        }

        // GET: Smes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Smes.ToListAsync());
        }

        // GET: Smes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sme = await _context.Smes
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (sme == null)
            {
                return NotFound();
            }

            return View(sme);
        }

        // GET: Smes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Smes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,LastName,Title")] Sme sme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sme);
        }

        // GET: Smes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sme = await _context.Smes.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (sme == null)
            {
                return NotFound();
            }
            return View(sme);
        }

        // POST: Smes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,FirstName,LastName,Title")] Sme sme)
        {
            if (id != sme.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmeExists(sme.EmployeeID))
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
            return View(sme);
        }

        // GET: Smes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sme = await _context.Smes
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (sme == null)
            {
                return NotFound();
            }

            return View(sme);
        }

        // POST: Smes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sme = await _context.Smes.SingleOrDefaultAsync(m => m.EmployeeID == id);
            _context.Smes.Remove(sme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmeExists(string id)
        {
            return _context.Smes.Any(e => e.EmployeeID == id);
        }
    }
}
