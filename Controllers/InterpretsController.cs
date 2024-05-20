using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpravaUdalosti.Data;
using SpravaUdalosti.Models;

namespace SpravaUdalosti.Controllers
{
    public class InterpretsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterpretsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interprets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interprets.ToListAsync());
        }

        // GET: Interprets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interprets = await _context.Interprets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interprets == null)
            {
                return NotFound();
            }

            return View(interprets);
        }

        // GET: Interprets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interprets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazevInterpreta,PopisInterpreta,HudebniZanr,ZemePuvodu")] Interprets interprets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interprets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interprets);
        }

        // GET: Interprets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interprets = await _context.Interprets.FindAsync(id);
            if (interprets == null)
            {
                return NotFound();
            }
            return View(interprets);
        }

        // POST: Interprets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazevInterpreta,PopisInterpreta,HudebniZanr,ZemePuvodu")] Interprets interprets)
        {
            if (id != interprets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interprets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterpretsExists(interprets.Id))
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
            return View(interprets);
        }

        // GET: Interprets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interprets = await _context.Interprets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interprets == null)
            {
                return NotFound();
            }

            return View(interprets);
        }

        // POST: Interprets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interprets = await _context.Interprets.FindAsync(id);
            if (interprets != null)
            {
                _context.Interprets.Remove(interprets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterpretsExists(int id)
        {
            return _context.Interprets.Any(e => e.Id == id);
        }
    }
}
