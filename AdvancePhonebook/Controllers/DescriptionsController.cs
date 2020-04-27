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
    public class DescriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DescriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Descriptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Descriptions.Include(d => d.Contact);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Descriptions/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descriptions = await _context.Descriptions
                .Include(d => d.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (descriptions == null)
            {
                return NotFound();
            }

            return View(descriptions);
        }

        // GET: Descriptions/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name");
            return View();
        }

        // POST: Descriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Topic,ContactId,Description,CreatedAt,UpdatedAt")] Descriptions descriptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descriptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name", descriptions.ContactId);
            return View(descriptions);
        }

        // GET: Descriptions/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descriptions = await _context.Descriptions.FindAsync(id);
            if (descriptions == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name", descriptions.ContactId);
            return View(descriptions);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Topic,ContactId,Description,CreatedAt,UpdatedAt")] Descriptions descriptions)
        {
            if (id != descriptions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descriptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescriptionsExists(descriptions.Id))
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
            ViewData["ContactId"] = new SelectList(_context.Contacts, "Id", "Name", descriptions.ContactId);
            return View(descriptions);
        }

        // GET: Descriptions/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descriptions = await _context.Descriptions
                .Include(d => d.Contact)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (descriptions == null)
            {
                return NotFound();
            }

            return View(descriptions);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var descriptions = await _context.Descriptions.FindAsync(id);
            _context.Descriptions.Remove(descriptions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescriptionsExists(long id)
        {
            return _context.Descriptions.Any(e => e.Id == id);
        }
    }
}
