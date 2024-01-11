using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projet_dotnet.Data;
using projet_dotnet.Models;

namespace projet_dotnet.Controllers
{
    public class Pfe_EtudiantController : Controller
    {
        private readonly Projet_dotnetContext _context;

        public Pfe_EtudiantController(Projet_dotnetContext context)
        {
            _context = context;
        }

        // GET: Pfe_Etudiant
        public async Task<IActionResult> Index()
        {
            var projet_dotnetContext = _context.Pfe_Etudiant.Include(p => p.Etudiant).Include(p => p.Pfe);
            return View(await projet_dotnetContext.ToListAsync());
        }

        // GET: Pfe_Etudiant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe_Etudiant = await _context.Pfe_Etudiant
                .Include(p => p.Etudiant)
                .Include(p => p.Pfe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pfe_Etudiant == null)
            {
                return NotFound();
            }

            return View(pfe_Etudiant);
        }

        // GET: Pfe_Etudiant/Create
        public IActionResult Create()
        {
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "ID", "Nom");
            ViewData["PfeId"] = new SelectList(_context.Pfe, "PfeId", "Titre");
            return View();
        }

        // POST: Pfe_Etudiant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PfeId,EtudiantId")] Pfe_Etudiant pfe_Etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pfe_Etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "ID", "Nom", pfe_Etudiant.EtudiantId);
            ViewData["PfeId"] = new SelectList(_context.Pfe, "PfeId", "Titre", pfe_Etudiant.PfeId);
            return View(pfe_Etudiant);
        }

        // GET: Pfe_Etudiant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe_Etudiant = await _context.Pfe_Etudiant.FindAsync(id);
            if (pfe_Etudiant == null)
            {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "ID", "Nom", pfe_Etudiant.EtudiantId);
            ViewData["PfeId"] = new SelectList(_context.Pfe, "PfeId", "Titre", pfe_Etudiant.PfeId);
            return View(pfe_Etudiant);
        }

        // POST: Pfe_Etudiant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,PfeId,EtudiantId")] Pfe_Etudiant pfe_Etudiant)
        {
            if (id != pfe_Etudiant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pfe_Etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pfe_EtudiantExists(pfe_Etudiant.ID))
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
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "ID", "Nom", pfe_Etudiant.EtudiantId);
            ViewData["PfeId"] = new SelectList(_context.Pfe, "PfeId", "Titre", pfe_Etudiant.PfeId);
            return View(pfe_Etudiant);
        }

        // GET: Pfe_Etudiant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pfe_Etudiant = await _context.Pfe_Etudiant
                .Include(p => p.Etudiant)
                .Include(p => p.Pfe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pfe_Etudiant == null)
            {
                return NotFound();
            }

            return View(pfe_Etudiant);
        }

        // POST: Pfe_Etudiant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var pfe_Etudiant = await _context.Pfe_Etudiant.FindAsync(id);
            if (pfe_Etudiant != null)
            {
                _context.Pfe_Etudiant.Remove(pfe_Etudiant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pfe_EtudiantExists(int? id)
        {
            return _context.Pfe_Etudiant.Any(e => e.ID == id);
        }
    }
}
