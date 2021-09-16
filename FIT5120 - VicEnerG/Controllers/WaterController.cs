using FIT5120___VicEnerG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class WaterController : Controller
    {
        // GET: Water
        [HttpGet]
        public ActionResult CalculateWater()
        {
            var Model = new WaterViewModel();
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CalculateWater([Bind(Include = "Postcode, RoofSize")] WaterViewModel Model)
        {
            return View(Model);
        }
    }
}