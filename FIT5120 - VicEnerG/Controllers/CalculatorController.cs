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
        public async Task<ActionResult> CalculateOutput(int Postcode, int NumberPanels)
        {
            // This is a test for geocode api
            VicEnerGSystem VEG = new VicEnerGSystem();
            List<double> Coordinates = await VEG.GetGeocode(Postcode);
            IList<Station> StationList = db.StationSet.ToList();
            int NearestStationID = VEG.FindNearestStation(Coordinates, StationList);
            Station TargetStation = db.StationSet.Find(NearestStationID);
            Calculator calculator = new Calculator();
            IList<double> MonthlyOutput = calculator.Calculate(TargetStation.StationDataList(), NumberPanels);

            var Model = new CalculatorViewModel();
            Model.OutputList = MonthlyOutput;
            Model.Postcode = Postcode;
            Model.NumberPanels = NumberPanels;
            Model.AnnualOutput = MonthlyOutput.Sum();

            return View(Model);

        }
    }
}