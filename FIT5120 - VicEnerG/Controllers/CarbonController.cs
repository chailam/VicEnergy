using FIT5120___VicEnerG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class CarbonController : Controller
    {
        // GET: Carbon
        [HttpGet]
        public ActionResult CalculateCarbon()
        {
            var Model = new CarbonViewModel();
            return View(Model);
        }

        [HttpPost]
        public ActionResult CalculateCarbon([Bind(Include = "Postcode, NumberPanels")] CarbonViewModel Model)
        {
            return View(Model);
        }

    }
}