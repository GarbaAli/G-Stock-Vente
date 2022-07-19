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
    public class PaiementController : Controller
    {
        private readonly AppDbContext _bd;
        private readonly IPaiementRepository _paiement;

        public PaiementController(AppDbContext context, IPaiementRepository paiement)
        {
            _bd = context;
            _paiement = paiement;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _paiement.AllPaiement());
        }

        private bool PaiementExist(int id)
        {
            return _bd.paiements.Any(p => p.paiementId == id);
        }

        // GET: Fournisseur/AddOrEdit(Insert)
        // GET: Fournisseur/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Paiement());
            else
            {
                var paiementModel = await _paiement.GetPaiement(id);
                if (paiementModel == null)
                {
                    return NotFound();
                }
                return View(paiementModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("paiementId, libellePaiement, cdepaiement, statutPaiement, created_at, updated_at")] Paiement paiement)
        {
            
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    paiement.created_at = DateTime.Now;
                    paiement.updated_at = DateTime.Now;
                    paiement.statutPaiement = true;
                    await _paiement.CreatePaiement(paiement);

                }
                //Update
                else
                {
                    try
                    {
                        paiement.updated_at = DateTime.Now;
                        await _paiement.UpdatePaiement(paiement);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PaiementExist(paiement.paiementId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewPaiement", _bd.paiements.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", paiement) });
        }

        // GET: Paiement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var p = await _bd.paiements.FirstOrDefaultAsync(p => p.paiementId == id);
            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paiement.DeletePaiement(id);

            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewPaiement", _bd.paiements.ToList()) });
        }

        // GET: PaiementController/toogle/5
        public ActionResult Desactivate(int id)
        {
            var paie = _bd.paiements.Find(id);
            if (paie == null)
            {
                return NotFound();
            }
            else
            {
                if (paie.statutPaiement == true)
                {
                    paie.statutPaiement = false;
                }
                else
                {
                    paie.statutPaiement = true;
                }

                _paiement.UpdatePaiement(paie);
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
