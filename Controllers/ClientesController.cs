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
    public class ClientesController : Controller
    {
        private readonly TallerDS215Context _context;

        public ClientesController(TallerDS215Context context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(String OrdenA, string Buscar)
        {
            ViewData["OrdeNom"]  = String.IsNullOrEmpty(OrdenA) ? "nombre_desc" : "";
            ViewData["OrdeApell"] = OrdenA=="apellido_asc" ? "apellido_desc" : "apellido_asc";
            ViewData["OrdeCorreo"] = OrdenA == "correo_asc" ? "correo_desc" : "correo_asc";
            //ViewData["OrdeAntigue"] = OrdenA == "fecha_asc" ? "fecha_desc" : "fecha_desc";
            //podríamos agregar la fecha en la que se crea los clientes y poder hacer algo con su fideldiad
            ViewData["FiltroB"] = Buscar;

            var cliente = from s in _context.Cliente select s;
            if (!String.IsNullOrEmpty(Buscar))
            {
                cliente = cliente.Where(s => s.nombre.Contains(Buscar) || s.apellido.Contains(Buscar) || s.DUI.Contains(Buscar));
            }

            
            switch (OrdenA)
            {
                case "nombre_desc":
                    cliente = cliente.OrderBy(s => s.nombre);
                    break;
                case "apellido_asc":
                    cliente = cliente.OrderBy(s => s.apellido);
                    break;
                case "apellido_desc":
                    cliente = cliente.OrderByDescending(s => s.apellido);
                    break;
                case "correo_asc":
                    cliente = cliente.OrderBy(s => s.correo);
                    break;
                case "correo_desc":
                    cliente = cliente.OrderByDescending(s => s.correo);
                    break;
                default:
                    cliente = cliente.OrderBy(s => s.nombre);
                    break;
            }

            return View(await cliente.AsNoTracking().ToListAsync());
           // return View(await _context.Cliente.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.DUI == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DUI,nombre,apellido,correo,telefono")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DUI,nombre,apellido,correo,telefono")] Cliente cliente)
        {
            if (id != cliente.DUI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.DUI))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.DUI == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(string id)
        {
            return _context.Cliente.Any(e => e.DUI == id);
        }
    }
}
