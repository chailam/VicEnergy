using FIT5120___VicEnerG.Models;
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
        private VicEnerG_ModelContainer db = new VicEnerG_ModelContainer();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(int postcode)
        {
            // This is a test for geocode api
            VicEnerGSystem VEG = new VicEnerGSystem();
            List<double> Coordinates =  await VEG.GetGeocode(postcode);
            IList<Station> StationList = db.StationSet.ToList();
            int NearestStationID = VEG.FindNearestStation(Coordinates, StationList);

            ViewBag.Message = Coordinates[0] + ", " + Coordinates[1] + "," + NearestStationID;
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