﻿using FIT5120___VicEnerG.Models;
using FIT5120___VicEnerG.ViewModels;
using Newtonsoft.Json;
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

        [HttpGet]
        public ActionResult CalculateOutput()
        {
            var Model = new CalculatorViewModel();
            return View(Model);
        }
        //This function is for the logic of when user input another postcode in the input box and there will be a
        // bar chart with two columns generate.
        public async Task<String> Compare(int Postcode, int NumberPanels)
        {
            //Initialize
            VicEnerGSystem VEG = new VicEnerGSystem();
            //Use the postcode which from the input box and check the data in staion
            List<double> Coordinates = await VEG.GetGeocode(Postcode);
            IList<Station> StationList = db.StationSet.ToList();
            int NearestStationID = VEG.FindNearestStation(Coordinates, StationList);
            Station TargetStation = db.StationSet.Find(NearestStationID);
            Calculator calculator = new Calculator();
            IList<double> MonthlyOutput = calculator.CalculateSolarOutput(TargetStation.StationDataRadiations(), NumberPanels);

            var dataList = new
            {
                Postcode = Postcode,
                OutputList = MonthlyOutput
            };
            ViewBag.stationList = dataList;
            var jsonData = JsonConvert.SerializeObject(dataList);
            return jsonData;
        }

        // This is the controller for Calculator page. It collectes data from the website, pass the data through different methods
        // Eventually display the information on the webpage with a Viewmodel.
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
                // Get all information from all the staion in Victoria from the database
                IList<Station> StationList = db.StationSet.ToList();
                // Pass the coordinate of the postcode to FindNearestStation method along with all station data
                int NearestStationID = VEG.FindNearestStation(Coordinates, StationList);
                // Find the corresponding station based on the given station number 
                Station TargetStation = db.StationSet.Find(NearestStationID);
                // Initial the calculator
                Calculator calculator = new Calculator();
                // Calculate the 12 months solar output of a given station with specific amount of panels installed
                IList<double> MonthlyOutput = calculator.CalculateSolarOutput(TargetStation.StationDataRadiations(), Model.NumberPanels);
                // Calculate the amount of CO2 corresponding to the amount of kwh electricity
                double CO2 = calculator.CalculateCO2(MonthlyOutput.Sum());
                // Get all information of all appliances from the database
                IList<Appliance> ApplianceList = db.ApplianceSet.ToList();
                // Pass the parameter to the calculator to calculate extra hours for each appliances
                IDictionary<String, List<int>> ApplianceExtraHours = calculator.CalculateUsage(ApplianceList, MonthlyOutput);

                // Calculate the monthly average energy output of Victoria by given solar radiation
                IList<double> VictoriaRadiation = new List<double>()
                {187.84, 154.0059259, 120.1309259, 94.06222222, 68.84055556, 45.70203704, 60.65203704, 82.14037037, 110.3937037, 129.3333333, 179.1027778, 191.8737037};
                IList<double> VictoriaAverage = calculator.CalculateSolarOutput(VictoriaRadiation, Model.NumberPanels);

                // Pass all necessary information to the viewModel and Viewbag
                Model.OutputList = MonthlyOutput;
                Model.AnnualOutput = MonthlyOutput.Sum();
                Model.Station = TargetStation;
                Model.CO2 = CO2;
                Model.Extrahours = ApplianceExtraHours;
                Model.VictoriaAverage = VictoriaAverage;
                ViewBag.Month = Enum.GetNames(typeof(Months)).ToList();
            }
            return View(Model);
        }
    }

    // Create a enum to store months name
    public enum Months{
        Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec
    }
}