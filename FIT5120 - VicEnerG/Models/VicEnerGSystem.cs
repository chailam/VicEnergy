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
            // This apikey is for authentication for using Mapbox api
            String api_key = "pk.eyJ1IjoiaGluOTciLCJhIjoiY2tzajg0cTBxMGl4ejJ3b3huNW52NTJlMyJ9.wPk2UciErCCZhyKdmfkpLQ";
            String defaultURL = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
            String requestURL = defaultURL + postcode + "%20Victoria%20Australia.json?access_token=" + api_key;

            // Define a api client to request api
            ApiClient = new HttpClient();
            using (HttpResponseMessage response = await ApiClient.GetAsync(requestURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Read the responded json document into a string
                    String json = response.Content.ReadAsStringAsync().Result;
                    JObject obj = JObject.Parse(json);
                    // Directly cast data from json file
                    double Latitude = (double)obj["features"][0]["geometry"]["coordinates"][0];
                    double Longitude = (double)obj["features"][0]["geometry"]["coordinates"][1];
                    List<double> coordinates = new List<double>() { Latitude, Longitude };
                    // The coordinates will be stores as a list
                    return coordinates;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        // This method will find the cloest station of the given postcode and return that station number
        public int FindNearestStation(List<double> Coordinates, IList<Station> StationList) 
        {
            // Pre-define variables
            int NearestStationID = 0;
            // 12800 is the distance across the earth
            double NearestDistance = 12800;
            // First value of coordinate will be the latitude of given postcode
            double TargetLat = Coordinates[0];
            // Second value of coordinate will be the longitude of given postcode
            double TargetLon = Coordinates[1];

            // This loop will find the cloest station by calculating the distance different between the postcode and each station in Database
            foreach(Station s in StationList) 
            {
                // Formula for calculating the distance
                double Distance = Math.Sqrt(Math.Pow(TargetLat - s.stationLat, 2) + Math.Pow(TargetLon - s.stationLon, 2));
                if (Distance < NearestDistance)
                {
                    // Update the variable if a shorter distance is found
                    NearestDistance = Distance;
                    NearestStationID = s.stationNumber;
                }
            }
            return NearestStationID;
        }
    }
}