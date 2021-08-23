using FIT5120___VicEnerG.Models;
using System;
using System.Collections.Generic;
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

    public int Postcode { get; set; }

    public int NumberPanels { get; set; }

    public double AnnualOutput { get; set; }

    public Station Station{ get; set; }
    }
}