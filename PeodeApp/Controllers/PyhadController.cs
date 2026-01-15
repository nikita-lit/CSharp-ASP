using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeodeApp.Data;
using PeodeApp.Models;

namespace PeodeApp.Controllers
{
    [Authorize(Roles = "Admin")] // Ainult sisse logitud kasutajale
    public class PyhadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PyhadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pyhad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pyhad.ToListAsync());
        }

        // GET: Pyhad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyha = await _context.Pyhad
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pyha == null)
            {
                return NotFound();
            }

            return View(pyha);
        }

        // GET: Pyhad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pyhad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nimi,Kuupaev")] Pyha pyha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pyha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pyha);
        }

        // GET: Pyhad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyha = await _context.Pyhad.FindAsync(id);
            if (pyha == null)
            {
                return NotFound();
            }
            return View(pyha);
        }

        // POST: Pyhad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nimi,Kuupaev")] Pyha pyha)
        {
            if (id != pyha.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pyha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PyhaExists(pyha.ID))
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
            return View(pyha);
        }

        // GET: Pyhad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyha = await _context.Pyhad
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pyha == null)
            {
                return NotFound();
            }

            return View(pyha);
        }

        // POST: Pyhad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pyha = await _context.Pyhad.FindAsync(id);
            if (pyha != null)
            {
                _context.Pyhad.Remove(pyha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PyhaExists(int id)
        {
            return _context.Pyhad.Any(e => e.ID == id);
        }
    }
}
