﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5120___VicEnerG.ViewModels
{
    public class WaterViewModel
    {

        public WaterViewModel()
        {
            MonthlyHarvest = new List<double>();
            VictoriaAverage = new List<double>();
        }

        [Range(1, Int32.MaxValue, ErrorMessage = "The minimum roof size is 1 square meter")]
        [Required(ErrorMessage = "Roofsize is required")]
        public double RoofSize { get; set; }

        [Range(3000, 3999, ErrorMessage = "Victoria postcode is in between 3000-3999")]
        [Required(ErrorMessage = "Postcode is required")]
        public int Postcode { get; set; }

        public int AnnualRainFall { get; set; }

        public double RainHarvest { get; set; }

        public IList<double> MonthlyHarvest { get; set; }

        public IList<double> VictoriaAverage { get; set; }

    }
}