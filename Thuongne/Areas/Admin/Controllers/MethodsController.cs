using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Thuongne.Models;

namespace Thuongne.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MethodsController : Controller
    {
        private readonly Web1Context _context;

        public MethodsController(Web1Context context)
        {
            _context = context;
        }

        // GET: Admin/Methods
        public async Task<IActionResult> Index()
        {
              return _context.Methods != null ? 
                          View(await _context.Methods.ToListAsync()) :
                          Problem("Entity set 'Web1Context.Methods'  is null.");
        }

        // GET: Admin/Methods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Methods == null)
            {
                return NotFound();
            }

            var @method = await _context.Methods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@method == null)
            {
                return NotFound();
            }

            return View(@method);
        }

        // GET: Admin/Methods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Methods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MetName,Title")] Method @method)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@method);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@method);
        }

        // GET: Admin/Methods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Methods == null)
            {
                return NotFound();
            }

            var @method = await _context.Methods.FindAsync(id);
            if (@method == null)
            {
                return NotFound();
            }
            return View(@method);
        }

        // POST: Admin/Methods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MetName,Title")] Method @method)
        {
            if (id != @method.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@method);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodExists(@method.Id))
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
            return View(@method);
        }

        // GET: Admin/Methods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Methods == null)
            {
                return NotFound();
            }

            var @method = await _context.Methods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@method == null)
            {
                return NotFound();
            }

            return View(@method);
        }

        // POST: Admin/Methods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Methods == null)
            {
                return Problem("Entity set 'Web1Context.Methods'  is null.");
            }
            var @method = await _context.Methods.FindAsync(id);
            if (@method != null)
            {
                _context.Methods.Remove(@method);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodExists(int id)
        {
          return (_context.Methods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
