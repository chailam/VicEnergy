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


        public IList<double> Calculate(IList<double> StationData, int SystemSize)    
        {
            IList<double> TotalOutput = new List<double>();
            foreach (double Radiation in StationData)
            {
                double EachOutput = area * efficiency * performanceRatio * Radiation * SystemSize;
                TotalOutput.Add(EachOutput);
            }
            return TotalOutput;
        }
    }
}
