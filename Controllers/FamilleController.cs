using G_Stock_Vente.Models;
using G_Stock_Vente.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static G_Stock_Vente.Helper;

namespace G_Stock_Vente.Controllers
{
    public class FamilleController : Controller
    {

        private readonly AppDbContext _bd;
        private readonly IFamilleRepository _famille;

        public FamilleController(AppDbContext context, IFamilleRepository famille)
        {
            _bd = context;
            _famille = famille;
        }
        public async Task<IActionResult> Index()
        {
            var fa = await _famille.AllFamile();
            return View(fa);
        }
        private bool FamilleExist(int id)
        {
            return _bd.familles.Any(f => f.familleId == id);
        }

        // GET: Famille/AddOrEdit(Insert)
        // GET: Famille/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Famille());
            else
            {
                var FamillyModel = await _famille.GetFamille(id);
                if (FamillyModel == null)
                {
                    return NotFound();
                }
                return View(FamillyModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("FamilleId, libelleFamille, codeFamille, statusFamille, created_at, updated_at")] Famille famille)
        {

            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    famille.created_at = DateTime.Now;
                    famille.updated_at = DateTime.Now;
                    famille.statusFamille = true;
                    await _famille.CreateFamille(famille);
                }
                //Update
                else
                {
                    try
                    {
                        famille.updated_at = DateTime.Now;
                        await _famille.UpdateFamille(famille);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FamilleExist(famille.familleId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewPartialFamilly", _bd.familles.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", famille) });
        }

        // GET: Famille/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fa = await _bd.familles.FirstOrDefaultAsync(f => f.familleId == id);
            if (fa == null)
            {
                return NotFound();
            }

            return View(fa);
        }
        // POST: /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _famille.DeleteFamille(id);

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewPartialFamilly", _bd.familles.ToList()) });
        }

        // GET: /toogle/5
        public ActionResult Desactivate(int id)
        {
            var famly = _bd.familles.Find(id);
            if (famly == null)
            {
                return NotFound();
            }
            else
            {
                if (famly.statusFamille == true)
                {
                    famly.statusFamille = false;
                }
                else
                {
                    famly.statusFamille = true;
                }

                famly.updated_at = DateTime.Now;
                _famille.UpdateFamille(famly);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
