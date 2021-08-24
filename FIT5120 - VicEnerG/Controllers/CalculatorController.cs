using FIT5120___VicEnerG.Models;
using FIT5120___VicEnerG.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class CalculatorController : Controller
    {
        private VicEnerG_ModelContainer db = new VicEnerG_ModelContainer();
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CalculateOutput()
        {
            var Model = new CalculatorViewModel();
            return View(Model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CalculateOutput([Bind(Include = "Postcode, NumberPanels")] CalculatorViewModel Model)
        {
            // Validate the input are valid
            if (ModelState.IsValid)
            {
                // Initial the VicEnerG System
                VicEnerGSystem VEG = new VicEnerGSystem();
                // Pass the postcode to GetGeocode method and return a list that contained the latitude and longitude of the postcode
                List<double> Coordinates = await VEG.GetGeocode(Model.Postcode);
                // Get all information from all the staion in Victoria from database
                IList<Station> StationList = db.StationSet.ToList();
                // Pass the coordinate of the postcode to FindNearestStation method along with all station data
                int NearestStationID = VEG.FindNearestStation(Coordinates, StationList);
                // Find the corresponding station based on the given station number 
                Station TargetStation = db.StationSet.Find(NearestStationID);
                // Initial the calculator
                Calculator calculator = new Calculator();
                // Calculate the 12 months solar output of a given station with specific amount of panels installed
                IList<double> MonthlyOutput = calculator.Calculate(TargetStation.StationDataList(), Model.NumberPanels);


                // Pass all necessary information to the viewModel and Viewbag
                Model.OutputList = MonthlyOutput;
                Model.AnnualOutput = MonthlyOutput.Sum();
                Model.Station = TargetStation;
                ViewBag.Month = Enum.GetNames(typeof(Months)).ToList();
            }
            return View(Model);
        }
    }

    public enum Months{
        Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec
    }
}