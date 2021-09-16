using FIT5120___VicEnerG.Models;
using FIT5120___VicEnerG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class WaterController : Controller
    {
        private VicEnerG_ModelContainer db = new VicEnerG_ModelContainer();
        // GET: Water
        [HttpGet]
        public ActionResult CalculateWater()
        {
            var Model = new WaterViewModel();
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CalculateWater([Bind(Include = "Postcode, RoofSize")] WaterViewModel Model)
        {
            if (ModelState.IsValid)
            {// Initial the VicEnerG System
                VicEnerGSystem VEG = new VicEnerGSystem();
                // Pass the postcode to GetGeocode method and return a list that contained the latitude and longitude of the postcode
                List<double> Coordinates = await VEG.GetGeocode(Model.Postcode);
                // Get all information from all the staion in Victoria from the database
                IList<Station> StationList = db.StationSet.ToList();
                // Pass the coordinate of the postcode to FindNearestStation method along with all station data
                int NearestStationID = VEG.FindNearestStation(Coordinates, StationList);
                // Find the corresponding station based on the given station number 
                Station TargetStation = db.StationSet.Find(NearestStationID);
                // Initial the calculator
                Calculator calculator = new Calculator();
                // Calculate the annual rainfall of the postcode
                int AnnualRainFall = TargetStation.StationAnnualRainFall();
                // Calculate the amount of the rainwater harvest by given roofSize
                Int64 RainHarvest = calculator.CalculateRainHarvested(AnnualRainFall, Model.RoofSize);
                // Pass all necessary information to the viewModel and Viewbag
                Model.AnnualRainFall = AnnualRainFall;
                Model.RainHarvest = RainHarvest;
            }
            return View(Model);
        }
    }
}