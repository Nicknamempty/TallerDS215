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
    public class EmpleadoesController : Controller
    {
        private readonly TallerDS215Context _context;

        public EmpleadoesController(TallerDS215Context context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index(string OrdenA, string Buscar)
        {
            ViewData["OrdeNom"] = String.IsNullOrEmpty(OrdenA) ? "nombre_desc" : "";
            ViewData["OrdeApell"] = OrdenA == "apellido_asc" ? "apellido_desc" : "apellido_desc";
            ViewData["OrdeCorreo"] = OrdenA == "correo_asc" ? "correo_desc" : "correo_desc";
            ViewData["OrdeSalario"] = OrdenA == "salario_asc" ? "salario_desc" : "salario_desc";
            ViewData["OrdeModPago"] = OrdenA == "pago_asc" ? "pago_desc" : "pago_desc";
            ViewData["OrdeArea"] = OrdenA == "area_asc" ? "area_desc" : "area_desc";
            ViewData["OrdeRol"] = OrdenA == "rol_asc" ? "rol_desc" : "rol_desc";
            ViewData["FiltroB"] = Buscar;

            var empleado = from s in _context.Empleado select s;
            if (!String.IsNullOrEmpty(Buscar))
            {
                empleado = empleado.Where(s => s.nombre.Contains(Buscar) || s.apellido.Contains(Buscar) || s.DUI.Contains(Buscar));
            }
            switch (OrdenA)
            {
                case "nombre_desc":
                    empleado = empleado.OrderBy(s => s.nombre);
                    break;
                case "apellido_asc":
                    empleado = empleado.OrderBy(s => s.apellido);
                    break;
                case "apellido_desc":
                    empleado = empleado.OrderByDescending(s => s.apellido);
                    break;
                case "correo_asc":
                    empleado = empleado.OrderBy(s => s.correo);
                    break;
                case "correo_desc":
                    empleado = empleado.OrderByDescending(s => s.correo);
                    break;
                case "salario_asc":
                    empleado = empleado.OrderBy(s => s.salario);
                    break;
                case "salario_desc":
                    empleado = empleado.OrderByDescending(s => s.salario);
                    break;
                case "area_asc":
                    empleado = empleado.OrderBy(s => s.Area);
                    break;
                case "area_desc":
                    empleado = empleado.OrderByDescending(s => s.Area);
                    break;
                case "rol_asc":
                    empleado = empleado.OrderBy(s => s.rol);
                    break;
                case "rol_desc":
                    empleado = empleado.OrderByDescending(s => s.rol);
                    break;
                default:
                    empleado = empleado.OrderBy(s => s.nombre);
                    break;
            }

            return View(await empleado.AsNoTracking().ToListAsync());
            //return View(await _context.Empleado.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.DUI == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DUI,nombre,apellido,correo,telefono,salario,modPago,Area,rol")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DUI,nombre,apellido,correo,telefono,salario,modPago,Area,rol")] Empleado empleado)
        {
            if (id != empleado.DUI)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.DUI))
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
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(m => m.DUI == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(string id)
        {
            return _context.Empleado.Any(e => e.DUI == id);
        }
    }
}
