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
    public class TuyenDungsController : Controller
    {
        private readonly Web1Context _context;

        public TuyenDungsController(Web1Context context)
        {
            _context = context;
        }

        // GET: Admin/TuyenDungs
        public async Task<IActionResult> Index()
        {
              return _context.TuyenDungs != null ? 
                          View(await _context.TuyenDungs.ToListAsync()) :
                          Problem("Entity set 'Web1Context.TuyenDungs'  is null.");
        }

        // GET: Admin/TuyenDungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TuyenDungs == null)
            {
                return NotFound();
            }

            var tuyenDung = await _context.TuyenDungs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tuyenDung == null)
            {
                return NotFound();
            }

            return View(tuyenDung);
        }

        // GET: Admin/TuyenDungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TuyenDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,WorkTime,Adress,Require,Benefit,Contact,Active")] TuyenDung tuyenDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuyenDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tuyenDung);
        }

        // GET: Admin/TuyenDungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TuyenDungs == null)
            {
                return NotFound();
            }

            var tuyenDung = await _context.TuyenDungs.FindAsync(id);
            if (tuyenDung == null)
            {
                return NotFound();
            }
            return View(tuyenDung);
        }

        // POST: Admin/TuyenDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,WorkTime,Adress,Require,Benefit,Contact,Active")] TuyenDung tuyenDung)
        {
            if (id != tuyenDung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuyenDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuyenDungExists(tuyenDung.Id))
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
            return View(tuyenDung);
        }

        // GET: Admin/TuyenDungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TuyenDungs == null)
            {
                return NotFound();
            }

            var tuyenDung = await _context.TuyenDungs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tuyenDung == null)
            {
                return NotFound();
            }

            return View(tuyenDung);
        }

        // POST: Admin/TuyenDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TuyenDungs == null)
            {
                return Problem("Entity set 'Web1Context.TuyenDungs'  is null.");
            }
            var tuyenDung = await _context.TuyenDungs.FindAsync(id);
            if (tuyenDung != null)
            {
                _context.TuyenDungs.Remove(tuyenDung);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuyenDungExists(int id)
        {
          return (_context.TuyenDungs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
