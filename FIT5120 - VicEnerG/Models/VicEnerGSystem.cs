using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FIT5120___VicEnerG.Models
{
    public class VicEnerGSystem
    {
        // Setup an Api client to call the api
        public static HttpClient ApiClient { get; set; }

        public async Task<List<double>> GetGeocode(int postcode)
        {
            // The inputted address will be passed here for geocoding
            String api_key = "pk.eyJ1IjoiaGluOTciLCJhIjoiY2tzajg0cTBxMGl4ejJ3b3huNW52NTJlMyJ9.wPk2UciErCCZhyKdmfkpLQ";
            String defaultURL = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
            String requestURL = defaultURL + postcode + "%20Victoria%20Australia.json?access_token=" + api_key;
            HttpClient ApiClient = new HttpClient();
            using (HttpResponseMessage response = await ApiClient.GetAsync(requestURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    //Address address = await response.Content.ReadAsAsync<Address>();
                    String json = response.Content.ReadAsStringAsync().Result;
                    JObject obj = JObject.Parse(json);
                    //Directly cast from json file
                    double Latitude = (double)obj["features"][0]["geometry"]["coordinates"][0];
                    double Longitude = (double)obj["features"][0]["geometry"]["coordinates"][1];
                    List<double> coordinates = new List<double>() { Latitude, Longitude };
                    //The coordinates will be stores as a list
                    return coordinates;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public int FindNearestStation(List<double> Coordinates, IList<Station> StationList) 
        {
            int NearestStationID = 0;
            double NearestDistance = 12800;
            double TargetLat = Coordinates[0];
            double TargetLon = Coordinates[1];

            foreach(Station s in StationList) 
            {
                double Distance = Math.Sqrt(Math.Pow(TargetLat - s.stationLat, 2) + Math.Pow(TargetLon - s.stationLon, 2));
                if (Distance < NearestDistance)
                {
                    NearestDistance = Distance;
                    NearestStationID = s.stationNumber;
                }
            }
            return NearestStationID;
        }
    }
}