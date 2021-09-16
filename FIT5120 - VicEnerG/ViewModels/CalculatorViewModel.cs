using FIT5120___VicEnerG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5120___VicEnerG.ViewModels
{
    // This is a viewmodel for displaying calculatorOutput page
    public class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            OutputList = new List<double>();
        }

        public IList<double> OutputList { get; set; }

        public IList<double> VictoriaAverage { get; set; }

        [Range(3000, 3999, ErrorMessage = "Victoria postcode is in between 3000-3999")]
        [Required(ErrorMessage = "Postcode is required")]
        public int Postcode { get; set; }

        [Required(ErrorMessage = "Number of panels is required")]
        [Range(1, 10, ErrorMessage = "The range of the estimation for solar panels is 1-10")]
        public int NumberPanels { get; set; }

        public double AnnualOutput { get; set; }
        public double CO2 { get; set; }
        public Station Station { get; set; }
        public IDictionary<String, List<int>> Extrahours { get; set; }
    }
}