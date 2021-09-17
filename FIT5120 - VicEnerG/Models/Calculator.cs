﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5120___VicEnerG.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Calculator
    {
        public int Id { get; set; }
        public double area { get; set; } = 1.6;
        public double efficiency { get; set; } = 0.156;
        public double performanceRatio { get; set; } = 0.75;

        // Some variables of the formula are pre-define with value
        // This method will calculate and return the monthly solar output of a given station
        public IList<double> CalculateSolarOutput(IList<double> StationData, int NumberPanels)
        {
            IList<double> TotalOutput = new List<double>();
            foreach (double Radiation in StationData)
            {
                // Formular: E = A * r * H * PR * Number of panels
                double EachOutput = area * efficiency * performanceRatio * Radiation * NumberPanels;
                // Round each output to 2 decimals only
                double RoundedOutput = Math.Round(EachOutput);
                TotalOutput.Add(RoundedOutput);
            }
            return TotalOutput;
        }

        // This method will calculate the amount of CO2 correspond to the elecrticity output
        public double CalculateCO2(double AnnualOutput)
        {
            // The formular
            double CO2 = Math.Round(AnnualOutput * 0.00113, 2);
            return CO2;
        }

        // This method will calculate the extra hours that can use by a list of appliances
        // The method will return a dictionary contained all appliances information along with their extra hours.
        public IDictionary<String, List<int>> CalculateUsage(IList<Appliance> ApplianceList, IList<double> MonthlyOutput)
        {
            // Initial the dictionary 
            IDictionary<String, List<int>> Usage = new Dictionary<String, List<int>>();
            foreach (Appliance App in ApplianceList)
            {
                double EachUsage = App.usage;
                List<int> Extrahours = new List<int>();
                foreach (double MonthlyData in MonthlyOutput)
                {
                    // Total divide each usage will result the extra hours 
                    int Result = (int)Math.Round(MonthlyData / EachUsage);
                    // Add the extra hours data into the list
                    Extrahours.Add(Result);
                }
                // Add the appliance object and the corresponding extra hours list into the dictionary
                Usage.Add(App.applianceName, Extrahours);
            }
            return Usage;
        }

        // This method will calculate the hours for trees in Victoria CBD to absorb given CO2
        // This method will return the hours
        public int CalculateAbsorptionHours(double CO2)
        {
            // Number of trees in City of Melbourne
            int TreesInCity = 70000;
            // Amount of CO2 in kg
            double CO2InKG = CO2 * 1000;
            // The amount of CO2 in kg can be absorbed per hour in CBD of Victoria
            double AbsorbRate = 0.00249 * TreesInCity;
            // The absorb hours will be the total amount of CO2 divide by the hourly absorb rate
            int Hours = (int)Math.Round(CO2InKG / AbsorbRate);

            return Hours;
        }

        // This method will calculate the equivalent kilometers that a passenger vehicle and light suv of given CO2
        public int CalcualteKMForLightCar(double CO2)
        {
            // Amount of CO2 in kg
            double CO2InKG = CO2 * 1000;
            // The Average emissions intensity for passenger cars and light SUVs was 149.5g/km
            double CarUsage = 0.1495;

            // Calculate the equivalent kilometer for passenger cars
            int KM = (int)Math.Round(CO2InKG / CarUsage);
            return KM;
        }

        // This method will calculate the equivalent kilometers that the heavy suv of given CO2
        public int CalcualteKMForHeaveyCar(double CO2)
        {
            // Amount of CO2 in kg
            double CO2InKG = CO2 * 1000;
            // The Average emissions intensity for passenger cars and light SUVs was 149.5g/km
            double CarUsage = 0.2167;

            // Calculate the equivalent kilometer for passenger cars
            int KM = (int)Math.Round(CO2InKG / CarUsage);
            return KM;
        }

        // This method will calculate the equivalent gallons of gasoline consumed by giving CO2
        public int CalculateGasoline(double CO2) {
            // 0.008887 metic tons of CO2 emitted per gallon of gasoline combusted
            double GasolineRate = 0.008887;
            // Calculate the equivalent gallons of gasoline consumed
            int liters = (int)Math.Round(CO2 / GasolineRate * 3.78);
            return liters;
        }

        // This method will calculate how many times that a phone can be fully charged by given CO2
        public int CalculatePhoneCharged(double CO2)
        {
            // Fully charging a phone will emit 0.00000 metic tons of CO2.
            double ChargeRate = 0.00000822;
            // Calculate the equivalent number of times for fully charge a phone by given CO2
            int Charges = (int)Math.Round(CO2 / ChargeRate);
            return Charges;
        }

        // This method will calculate the annual solar output generated by solar panels in Victoria
        public double CalculateVictoriaOutput(IList<PostcodeData> PostcodeDataList) {
            double Output = 0;
            foreach (PostcodeData PD in PostcodeDataList) {
                Output += PD.solarOutput;
            }
            return Output;
        }

        // This method will calculate the amount of rainwater harvest by giving roofsize
        public IList<double> CalculateRainHarvested(IList<double> Rainfall, double RoofSize) {
            IList<double> MonthlyHarvest = new List<double>();
            foreach (double eachmonth in Rainfall)
            {
                // Formular: Rain Harvest = rainfall * roofsize
                double EachOutput = Math.Round(eachmonth * RoofSize / 1018, 2);
                MonthlyHarvest.Add(EachOutput);
            }
            return MonthlyHarvest;
        }
    }
}
