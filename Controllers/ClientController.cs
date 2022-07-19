using G_Stock_Vente.Models;
using G_Stock_Vente.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _client;
        public ClientController(IClientRepository client)
        {
            _client = client;
        }
        // GET: ClientController
        public ActionResult Index()
        {
            var clts = _client.AllClient();
            return View(clts);
        }

        // GET: ClientController/Details/5
        public ActionResult Desactivate(int id)
        {
            var clt = _client.GetClient(id);
            if (clt == null)
            {
                return NotFound();
            }
            else
            {
                if (clt.statutClt == true)
                {
                    clt.statutClt = false;
                }
                else
                {
                    clt.statutClt = true;
                }

                _client.UpdateClient(clt);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                //const string V = "Clt";
                //client.codeClt = V +'_'+ client.clientId + '_' + client.villeClt;
                _client.CreateClient(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            var clt = _client.GetClient(id);
            if(clt != null)
            {
                return View(clt);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            try
            {
                _client.UpdateClient(client);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: ClientController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _client.DeleteClient(id);

            return Json(new { html = Helper.RenderRazorViewToString(this, "Index", _client.AllClient()) });
        }
    }
}
