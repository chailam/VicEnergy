using FIT5120___VicEnerG.Utilities;
using GeoJSON.Net.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(int postcode)
        {
            // This is a test for geocode api
            Geocoder geo = new Geocoder();
            List<double> coordinates =  await geo.GetGeocode(postcode);
            ViewBag.Message = coordinates[0] + "," + coordinates[1];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}