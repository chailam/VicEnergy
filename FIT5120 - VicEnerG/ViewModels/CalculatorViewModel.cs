﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5120___VicEnerG.ViewModels
{
    public class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            OutputList = new List<double>();
            ApplianceHours = new List<double>();
        }
    
    public IList<double> OutputList { get; set; }
    public IList<double> ApplianceHours { get; set; }

    public int Postcode { get; set; }

    public int NumberPanels { get; set; }

    public double AnnualOutput { get; set; }
    }
}