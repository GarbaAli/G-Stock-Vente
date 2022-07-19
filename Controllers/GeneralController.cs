using G_Stock_Vente.Models;
using G_Stock_Vente.Repository;
using G_Stock_Vente.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G_Stock_Vente.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IGeneralRepository _general;

        public GeneralController(IGeneralRepository info)
        {
                _general = info;
        }
        public IActionResult Index()
        {
            var generalVM = new GeneralVM();
            generalVM.infos = _general.GetInfos(1);
            return View(generalVM);
        }

        public IActionResult Init()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Init(General general)
        {
            _general.InitialInfos(general);
            return RedirectToAction("index");
        }
    }
}
