using G_Stock_Vente.Models;
using G_Stock_Vente.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static G_Stock_Vente.Helper;

namespace G_Stock_Vente.Controllers
{
    public class FournisseurController : Controller
    {
        private readonly IFournisseurRepository _fsseur;
        private readonly AppDbContext _bd;
        public FournisseurController(IFournisseurRepository fsseur, AppDbContext context)
        {
            _fsseur = fsseur;
            _bd = context;
        }

        private bool FsseurExist(int id)
        {
            return _bd.fournisseurs.Any(f => f.FsseurId == id);
        }
        // GET: FournisseurController
        public async Task<ActionResult> Index()
        {
            return View( await _fsseur.AllFsseurs());
        }

        // GET: Fournisseur/AddOrEdit(Insert)
        // GET: Fournisseur/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Fournisseur());
            else
            {
                var FournisseurModel = await _fsseur.GetFsseur(id);
                if (FournisseurModel == null)
                {
                    return NotFound();
                }
                return View(FournisseurModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("FsseurId,codeFsseur,nomFsseur,emailFsseur,phoneFsseur,postalFsseur,paysFsseur,villeFsseur,statutFsseur,createdFsseur")] Fournisseur fournisseur)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    fournisseur.createdFsseur = DateTime.Now;
                   await _fsseur.CreateFsseur(fournisseur);

                }
                //Update
                else
                {
                    try
                    {
                       await _fsseur.UpdateFsseur(fournisseur);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FsseurExist(fournisseur.FsseurId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewFsseur", _bd.fournisseurs.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", fournisseur) });
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var f = await _bd.fournisseurs.FirstOrDefaultAsync(f => f.FsseurId == id);
            if (f == null)
            {
                return NotFound();
            }

            return View(f);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _fsseur.DeleteFsseur(id);
            
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewFsseur", _bd.fournisseurs.ToList()) });
        }


        // GET: FournisseurController/toogle/5
        public ActionResult Desactivate(int id)
        {
            var fsseur = _bd.fournisseurs.FirstOrDefault(f => f.FsseurId == id);
            if (fsseur == null)
            {
                return NotFound();
            }
            else
            {
                if (fsseur.statutFsseur == true)
                {
                    fsseur.statutFsseur = false;
                }
                else
                {
                    fsseur.statutFsseur = true;
                }

                _fsseur.UpdateFsseur(fsseur);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
