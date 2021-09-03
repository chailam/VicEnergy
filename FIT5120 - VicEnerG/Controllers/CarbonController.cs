﻿using FIT5120___VicEnerG.Models;
using FIT5120___VicEnerG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FIT5120___VicEnerG.Controllers
{
    public class CarbonController : Controller
    {
        private VicEnerG_ModelContainer db = new VicEnerG_ModelContainer();

        // GET: Carbon
        [HttpGet]
        public ActionResult CalculateCarbon()
        {
            var Model = new CarbonViewModel();
            return View(Model);
        }

        [HttpPost]
        public async Task<ActionResult> CalculateCarbon([Bind(Include = "Postcode, NumberPanels")] CarbonViewModel Model)
        {
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
                IList<double> MonthlyOutput = calculator.CalculateSolarOutput(TargetStation.StationDataList(), Model.NumberPanels);
                // Calculate the amount of CO2 corresponding to the amount of kwh electricity
                double CO2 = calculator.CalculateCO2(MonthlyOutput.Sum());
                // Calculate the hours for trees in Victoria CBD to absorb given CO2
                int AbsorbHours = calculator.CalculateAbsorptionHours(CO2);
                // This method will calculate the equivalent kilometers that a passenger vehicle and light suv of given CO2
                int LightVehicle = calculator.CalcualteKMForLightCar(CO2);
                // This method will calculate the equivalent kilometers that the heavy suv of given CO2
                int HeavyVehicle = calculator.CalcualteKMForHeaveyCar(CO2);
                // This method will calculate how many times that a phone can be fully charged by given CO2
                int PhoneCharges = calculator.CalculatePhoneCharged(CO2);
                // This method will calculate the equivalent gallons of gasoline consumed by giving CO2
                int Gallons = calculator.CalculateGasoline(CO2);
                // Pass all necessary information to the viewModel and Viewbag
                Model.CO2 = CO2;
                Model.AbsorbHours = AbsorbHours;
                Model.LightVehicle = LightVehicle;
                Model.HeavyVehicle = HeavyVehicle;
                Model.PhoneCharges = PhoneCharges;
                Model.Gallons = Gallons;
            }
            return View(Model);
        }

    }
}