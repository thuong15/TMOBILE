﻿using System;
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
    public class TransactStatusController : Controller
    {
        private readonly Web1Context _context;

        public TransactStatusController(Web1Context context)
        {
            _context = context;
        }

        // GET: Admin/TransactStatus
        public async Task<IActionResult> Index()
        {
              return _context.TransactStatuses != null ? 
                          View(await _context.TransactStatuses.ToListAsync()) :
                          Problem("Entity set 'Web1Context.TransactStatuses'  is null.");
        }

        // GET: Admin/TransactStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransactStatuses == null)
            {
                return NotFound();
            }

            var transactStatus = await _context.TransactStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transactStatus == null)
            {
                return NotFound();
            }

            return View(transactStatus);
        }

        // GET: Admin/TransactStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TransactStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TranName,Description")] TransactStatus transactStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactStatus);
        }

        // GET: Admin/TransactStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactStatuses == null)
            {
                return NotFound();
            }

            var transactStatus = await _context.TransactStatuses.FindAsync(id);
            if (transactStatus == null)
            {
                return NotFound();
            }
            return View(transactStatus);
        }

        // POST: Admin/TransactStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TranName,Description")] TransactStatus transactStatus)
        {
            if (id != transactStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactStatusExists(transactStatus.Id))
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
            return View(transactStatus);
        }

        // GET: Admin/TransactStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactStatuses == null)
            {
                return NotFound();
            }

            var transactStatus = await _context.TransactStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transactStatus == null)
            {
                return NotFound();
            }

            return View(transactStatus);
        }

        // POST: Admin/TransactStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactStatuses == null)
            {
                return Problem("Entity set 'Web1Context.TransactStatuses'  is null.");
            }
            var transactStatus = await _context.TransactStatuses.FindAsync(id);
            if (transactStatus != null)
            {
                _context.TransactStatuses.Remove(transactStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactStatusExists(int id)
        {
          return (_context.TransactStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
