﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Offertguiden.Models;

namespace Offertguiden.Controllers
{
    public class ReferencesController : Controller
    {
        private readonly OffertguidenContext _context;

        public ReferencesController(OffertguidenContext context)
        {
            _context = context;
        }

        // GET: References
        public async Task<IActionResult> Index()
        {
            return View(await _context.References.ToListAsync());
        }
        public async Task<IActionResult> References()
        {
            return View(await _context.References.ToListAsync());
        }

        // GET: References/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .SingleOrDefaultAsync(m => m.ReferenceId == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: References/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferenceId,Title,Text,Date,Picture")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }

        // GET: References/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceId == id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReferenceId,Title,Text,Date,Picture")] Reference reference)
        {
            if (id != reference.ReferenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.ReferenceId))
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
            return View(reference);
        }

        // GET: References/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.References
                .SingleOrDefaultAsync(m => m.ReferenceId == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceId == id);
            _context.References.Remove(reference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceExists(int id)
        {
            return _context.References.Any(e => e.ReferenceId == id);
        }
    }
}
