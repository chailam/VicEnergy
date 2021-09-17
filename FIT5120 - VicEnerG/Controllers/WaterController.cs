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
                int AnnualRainFall = (int)TargetStation.StationMonthlyRainfalls().Sum();
                // Calculate the amount of the rainwater harvest by given roofSize
                IList<double> MonthlyHarvest = calculator.CalculateRainHarvested(TargetStation.StationMonthlyRainfalls(), Model.RoofSize);
                double TotalRainHarvest = MonthlyHarvest.Sum();

                // Calculate the monthly average rainwater harvested of Victoria by given size of Roof
                IList<double> VictoriaAverageRainFall = new List<double>()
                {84.984,28.56133333,55.52066667,26.84333333,67.44466667,89.38933333,44.346,78.926,55.524,89.218,39.59466667,45.30933333};
                IList<double> VictoriaAverageHarvest = calculator.CalculateRainHarvested(VictoriaAverageRainFall, Model.RoofSize);


                // Pass all necessary information to the viewModel and Viewbag
                Model.AnnualRainFall = AnnualRainFall;
                Model.MonthlyHarvest = MonthlyHarvest;
                Model.RainHarvest = TotalRainHarvest;
                Model.VictoriaAverage = VictoriaAverageHarvest;
                ViewBag.Month = Enum.GetNames(typeof(Months)).ToList();
            }
            return View(Model);
        }
    }
}