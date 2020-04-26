using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancePhonebook.Data;
using AdvancePhonebook.Models;

namespace AdvancePhonebook.Controllers
{
    public class EnterprisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnterprisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enterprises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enterprises.ToListAsync());
        }

        // GET: Enterprises/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprises = await _context.Enterprises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enterprises == null)
            {
                return NotFound();
            }

            return View(enterprises);
        }

        // GET: Enterprises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enterprises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,Fax,Address,PostalCode,CreatedAt,UpdatedAt")] Enterprises enterprises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enterprises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enterprises);
        }

        // GET: Enterprises/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprises = await _context.Enterprises.FindAsync(id);
            if (enterprises == null)
            {
                return NotFound();
            }
            return View(enterprises);
        }

        // POST: Enterprises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Email,PhoneNumber,Fax,Address,PostalCode,CreatedAt,UpdatedAt")] Enterprises enterprises)
        {
            if (id != enterprises.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enterprises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnterprisesExists(enterprises.Id))
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
            return View(enterprises);
        }

        // GET: Enterprises/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprises = await _context.Enterprises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enterprises == null)
            {
                return NotFound();
            }

            return View(enterprises);
        }

        // POST: Enterprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var enterprises = await _context.Enterprises.FindAsync(id);
            _context.Enterprises.Remove(enterprises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnterprisesExists(long id)
        {
            return _context.Enterprises.Any(e => e.Id == id);
        }
    }
}
