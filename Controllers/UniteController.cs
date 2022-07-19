using G_Stock_Vente.Models;
using G_Stock_Vente.Repository;
using G_Stock_Vente.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static G_Stock_Vente.Helper;

namespace G_Stock_Vente.Controllers
{
    public class UniteController : Controller
    {
        private readonly IUniteRepository _unite;
        private readonly AppDbContext _appDbContext;
        public UniteController(IUniteRepository unite, AppDbContext context)
        {
            _unite = unite;
            _appDbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var unitesVm = new UniteVm();
            unitesVm.unites = await _unite.GetAllUniteAsync();
            return View(unitesVm);
        }

        //GET: Unite/Create Or Edit
        [NoDirectAccess]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Unite());
            }
            else
            {
                var u = _unite.GetUniteById(id);
                if (u == null)
                {
                    return NotFound();
                }
                return View(u);
            }

        }

        //POST: Unite/Create Or Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditAsync(int id, [Bind("uniteId, libelleUnite, codeUnite, statutUnite, Created, updated")] Unite unite)
        {
            if (ModelState.IsValid)
            {
                //si l'id nexiste pas ou est null on creer l'unite
                if (id == 0)
                {
                   await _unite.CreateUniteAsync(unite);

                }
                else //On met a jour les donnees
                {
                    try
                    {
                      await  _unite.UpdateUnite(unite);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        var res = _unite.GetUniteById(unite.uniteId);
                        if (res == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }

                        throw;
                    }
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllUnite", _appDbContext.Unites.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", unite) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var res =  _unite.DeleteUnite(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllUnite", _appDbContext.Unites.ToList()) });
        }

        [HttpPost, ActionName("Desactivate")]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult DesactiveUnite(int id)
        {
            var u = _appDbContext.Unites.Find(id);
            if (u.statutUnite)
            {
                u.statutUnite = false;
            }
            else
            {
                u.statutUnite = true;
            }
            
            _unite.UpdateUnite(u);
            return RedirectToAction("index");
        }
    }
}
