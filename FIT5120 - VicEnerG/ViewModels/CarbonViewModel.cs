using FIT5120___VicEnerG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5120___VicEnerG.ViewModels
{
    // This is a viewmodel for displaying calculatorOutput page
    public class CarbonViewModel
    {
        [Range(3000, 3999, ErrorMessage = "Victoria postcode is in between 3000-3999")]
        [Required(ErrorMessage = "Postcode is required")]
        public int Postcode { get; set; }

        [Required(ErrorMessage = "Number of panels is required")]
        [Range(1, 10, ErrorMessage = "The maximums estimation is 10 solar panels")]
        public int NumberPanels { get; set; }
        public double ElectricityOutput { get; set; }
        public double CO2 { get; set; }
        public int AbsorbHours { get; set; }
        public int LightVehicle { get; set; }
        public int HeavyVehicle { get; set; }
        public int PhoneCharges { get; set; }
        public int Gasoline { get; set; }
        public double SuburbTotalCO2 { get; set; }
        public double StateMonthlyCO2 { get; set; }
    }
}