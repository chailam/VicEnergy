using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5120___VicEnerG.Models
{
    public class VicEnerGSystem
    {
        public Calculator Calculator { get; set; }

        public IList<Station> StationList { get; set; }

        public IList<Appliance> Appliances { get; set; }
    }
}