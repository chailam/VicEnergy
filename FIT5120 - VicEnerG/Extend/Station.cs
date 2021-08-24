using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT5120___VicEnerG.Models
{
    // This is the extend class of Station Class
    public partial class Station
    {
        // This method will return the monthly radiation of a given station from Jan to Dec
        public IList<double> StationDataList()
        {
            IList<double> data = new List<double>();
            // Order the data from Jan to Dec
            StationData = StationData.OrderBy(r => r.month).ToList();
            foreach (StationData EachStation in StationData)
            {
                data.Add(EachStation.monthRadiation);
            }
            return data;
        }
    }
}