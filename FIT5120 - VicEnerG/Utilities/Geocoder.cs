using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FIT5120___VicEnerG.Utilities
{
    public class Geocoder
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
                    double Latitude= (double)obj["features"][0]["geometry"]["coordinates"][0];
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
    }
}
//{ "type":"FeatureCollection",
//        "query":["3145","victoria"],
//        "features":[{ "id":"postcode.12680556385218410","type":"Feature","place_type":["postcode"],"relevance":1,"properties":{ },"text":"3145","place_name":"3145, Caulfield East, Victoria, Australia","bbox":[145.034603,-37.892976,145.092201,-37.863409],"center":[145.04,-37.88],"geometry":{ "type":"Point","coordinates":[145.04,-37.88]},"context":[{ "id":"locality.12225338183745060","wikidata":"Q5054508","text":"Caulfield East"},{ "id":"place.7068896531111320","wikidata":"Q3141","text":"Melbourne"},{ "id":"region.10151275538899450","wikidata":"Q36687","short_code":"AU-VIC","text":"Victoria"},{ "id":"country.9968792518346070","wikidata":"Q408","short_code":"au","text":"Australia"}]},{ "id":"address.3283314791151360","type":"Feature","place_type":["address"],"relevance":1,"properties":{ "accuracy":"interpolated"},"text":"Great Western Highway","place_name":"3145 Great Western Highway, Hartley New South Wales 2790, Australia","matching_text":"Victoria Pass","matching_place_name":"3145 Victoria Pass, Hartley New South Wales 2790, Australia","center":[150.15364,-33.524547],"geometry":{ "type":"Point","coordinates":[150.15364,-33.524547],"interpolated":true,"omitted":true},"address":"3145","context":[{ "id":"postcode.10740107901413440","text":"2790"},{ "id":"locality.10962198591368340","text":"Hartley"},{ "id":"region.19913417492553050","wikidata":"Q3224","short_code":"AU-NSW","text":"New South Wales"},{ "id":"country.9968792518346070","wikidata":"Q408","short_code":"au","text":"Australia"}]},{ "id":"address.4657289531267870","type":"Feature","place_type":["address"],"relevance":1,"properties":{ "accuracy":"interpolated"},"text":"Great Western Highway","place_name":"3145 Great Western Highway, South Bowenfels New South Wales 2790, Australia","matching_text":"Victoria Pass","matching_place_name":"3145 Victoria Pass, South Bowenfels New South Wales 2790, Australia","center":[150.121819,-33.514133],"geometry":{ "type":"Point","coordinates":[150.121819,-33.514133],"interpolated":true,"omitted":true},"address":"3145","context":[{ "id":"postcode.10740107901413440","text":"2790"},{ "id":"locality.7058689559752690","text":"South Bowenfels"},{ "id":"region.19913417492553050","wikidata":"Q3224","short_code":"AU-NSW","text":"New South Wales"},{ "id":"country.9968792518346070","wikidata":"Q408","short_code":"au","text":"Australia"}]},{ "id":"address.1903778749065396","type":"Feature","place_type":["address"],"relevance":1,"properties":{ "accuracy":"interpolated"},"text":"Great Western Highway","place_name":"3145 Great Western Highway, Meadow Flat New South Wales 2795, Australia","matching_text":"Victoria Pass","matching_place_name":"3145 Victoria Pass, Meadow Flat New South Wales 2795, Australia","center":[149.87708,-33.433159],"geometry":{ "type":"Point","coordinates":[149.87708,-33.433159],"interpolated":true,"omitted":true},"address":"3145","context":[{ "id":"postcode.10680340006216780","text":"2795"},{ "id":"locality.10747813357317940","text":"Meadow Flat"},{ "id":"region.19913417492553050","wikidata":"Q3224","short_code":"AU-NSW","text":"New South Wales"},{ "id":"country.9968792518346070","wikidata":"Q408","short_code":"au","text":"Australia"}]},{ "id":"address.7078552615705676","type":"Feature","place_type":["address"],"relevance":1,"properties":{ "accuracy":"interpolated"},"text":"Victoria Valley Road","place_name":"3145 Victoria Valley Road, Victoria Valley Tasmania 7140, Australia","center":[146.650081,-42.279531],"geometry":{ "type":"Point","coordinates":[146.650081,-42.279531],"interpolated":true,"omitted":true},"address":"3145","context":[{ "id":"postcode.3460681299737410","text":"7140"},{ "id":"locality.11439971948547460","text":"Victoria Valley"},{ "id":"region.10040615135819150","wikidata":"Q34366","short_code":"AU-TAS","text":"Tasmania"},{ "id":"country.9968792518346070","wikidata":"Q408","short_code":"au","text":"Australia"}]}],
//        "attribution":"NOTICE: © 2021 Mapbox and its suppliers. All rights reserved. Use of this data is subject to the Mapbox Terms of Service (https://www.mapbox.com/about/maps/). This response and the information it contains may not be retained. POI(s) provided by Foursquare."}