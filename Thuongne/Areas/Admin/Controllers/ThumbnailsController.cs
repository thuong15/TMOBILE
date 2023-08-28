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
    public class ThumbnailsController : Controller
    {
        private readonly Web1Context _context;
        private readonly IWebHostEnvironment v;
        public ThumbnailsController(Web1Context context, IWebHostEnvironment v)
        {
            _context = context;
            this.v = v;
        }

        // GET: Admin/Thumbnails
        public async Task<IActionResult> Index()
        {
            var web1Context = _context.Thumbnails.Include(t => t.Pro);
            return View(await web1Context.ToListAsync());
        }

        // GET: Admin/Thumbnails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thumbnails == null)
            {
                return NotFound();
            }

            var thumbnail = await _context.Thumbnails
                .Include(t => t.Pro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thumbnail == null)
            {
                return NotFound();
            }

            return View(thumbnail);
        }

        // GET: Admin/Thumbnails/Create
        public IActionResult Create()
        {
            ViewData["ProId"] = new SelectList(_context.Products, "Id", "ProName");
            return View();
        }

        // POST: Admin/Thumbnails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Thumb,ProId")] Thumbnail thumbnail, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                if (img != null && img.Length > 0)
                {
                    string uploadsFolder = Path.Combine(v.WebRootPath, "img");
                    string uniqueFileName = /*Guid.NewGuid().ToString() + "_" + */img.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await img.CopyToAsync(fileStream);
                    }
                    thumbnail.Thumb = /*"/img/" +*/ uniqueFileName;
                }
                _context.Add(thumbnail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProId"] = new SelectList(_context.Products, "Id", "ProName", thumbnail.ProId);
            return View(thumbnail);
        }

        // GET: Admin/Thumbnails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thumbnails == null)
            {
                return NotFound();
            }

            var thumbnail = await _context.Thumbnails.FindAsync(id);
            if (thumbnail == null)
            {
                return NotFound();
            }
            ViewData["ProId"] = new SelectList(_context.Products, "Id", "Id", thumbnail.ProId);
            return View(thumbnail);
        }

        // POST: Admin/Thumbnails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Thumb,ProId")] Thumbnail thumbnail)
        {
            if (id != thumbnail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thumbnail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThumbnailExists(thumbnail.Id))
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
            ViewData["ProId"] = new SelectList(_context.Products, "Id", "Id", thumbnail.ProId);
            return View(thumbnail);
        }

        // GET: Admin/Thumbnails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thumbnails == null)
            {
                return NotFound();
            }

            var thumbnail = await _context.Thumbnails
                .Include(t => t.Pro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thumbnail == null)
            {
                return NotFound();
            }

            return View(thumbnail);
        }

        // POST: Admin/Thumbnails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thumbnails == null)
            {
                return Problem("Entity set 'Web1Context.Thumbnails'  is null.");
            }
            var thumbnail = await _context.Thumbnails.FindAsync(id);
            if (thumbnail != null)
            {
                _context.Thumbnails.Remove(thumbnail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThumbnailExists(int id)
        {
          return (_context.Thumbnails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
