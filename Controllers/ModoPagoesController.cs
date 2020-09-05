using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerDS215.Data;
using TallerDS215.Models;

namespace TallerDS215.Controllers
{
    public class ModoPagoesController : Controller
    {
        private readonly TallerDS215Context _context;

        public ModoPagoesController(TallerDS215Context context)
        {
            _context = context;
        }

        // GET: ModoPagoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModoPago.ToListAsync());
        }

        // GET: ModoPagoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPago
                .FirstOrDefaultAsync(m => m.ModoPagoID == id);
            if (modoPago == null)
            {
                return NotFound();
            }

            return View(modoPago);
        }

        // GET: ModoPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModoPagoID,ModoPagoNom")] ModoPago modoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modoPago);
        }

        // GET: ModoPagoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPago.FindAsync(id);
            if (modoPago == null)
            {
                return NotFound();
            }
            return View(modoPago);
        }

        // POST: ModoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModoPagoID,ModoPagoNom")] ModoPago modoPago)
        {
            if (id != modoPago.ModoPagoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModoPagoExists(modoPago.ModoPagoID))
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
            return View(modoPago);
        }

        // GET: ModoPagoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPago
                .FirstOrDefaultAsync(m => m.ModoPagoID == id);
            if (modoPago == null)
            {
                return NotFound();
            }

            return View(modoPago);
        }

        // POST: ModoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var modoPago = await _context.ModoPago.FindAsync(id);
            _context.ModoPago.Remove(modoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModoPagoExists(string id)
        {
            return _context.ModoPago.Any(e => e.ModoPagoID == id);
        }
    }
}
