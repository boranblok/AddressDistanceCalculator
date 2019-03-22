using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AdressDistance
{
    public class GoogleAPIWrapper
    {
        private static String _apiKey;

        static GoogleAPIWrapper()
        {
            _apiKey = ConfigurationManager.AppSettings["GoogleApiKey"];
        }
        public class GeoCodeResponse
        {
            public Decimal Latitute { get; set; }
            public Decimal Longtitude { get; set; }
            public Boolean HasValue { get; set; }
        }
        public static GeoCodeResponse GetAddressLocation(String address)
        {
            GeoCodeResponse returnValue = new GeoCodeResponse();

            StringBuilder request = new StringBuilder();
            request.Append("https://maps.googleapis.com/maps/api/geocode/json?region=be");
            request.Append("&address=");
            request.Append(HttpUtility.UrlEncode(address));
            request.Append("&key=");
            request.Append(_apiKey);

            String jsonResponse = DBHandler.Instance.GetCachedResponse(request.ToString());

            if(String.IsNullOrWhiteSpace(jsonResponse))
            {
                using (WebClient client = new WebClient())
                {
                    jsonResponse = client.DownloadString(request.ToString());
                    DBHandler.Instance.StoreResponseInCache(request.ToString(), jsonResponse);
                }
            }
            
            JObject response = JObject.Parse(jsonResponse);
            if ("OK".Equals(response["status"].Value<String>()))
            {
                JToken location = response["results"].First()["geometry"]["location"];
                returnValue.Latitute = location["lat"].Value<Decimal>();
                returnValue.Longtitude = location["lng"].Value<Decimal>();
                returnValue.HasValue = true;
            }

            return returnValue;
        }

        public static List<TravelTime> GetTravelTimes(DepartureAddress depAddr, List<DestinationAddress> destinations)
        {
            StringBuilder request = new StringBuilder();
            request.Append("https://maps.googleapis.com/maps/api/distancematrix/json?key=");
            request.Append(_apiKey);
            request.Append("&origins=");
            request.Append(depAddr.GetCoordinatesAsString());
            request.Append("&destinations=");
            Boolean first = true;
            foreach (var destination in destinations)
            {
                if (first)
                    first = false;
                else
                    request.Append('|');
                request.Append(destination.GetCoordinatesAsString());
            }

            String jsonResponse = DBHandler.Instance.GetCachedResponse(request.ToString());

            if (String.IsNullOrWhiteSpace(jsonResponse))
            {
                using (WebClient client = new WebClient())
                {
                    jsonResponse = client.DownloadString(request.ToString());
                    DBHandler.Instance.StoreResponseInCache(request.ToString(), jsonResponse);
                }
            }

            List<TravelTime> times = new List<TravelTime>(destinations.Count);

            JObject response = JObject.Parse(jsonResponse);

            for(int i = 0; i < destinations.Count; i++)
            {
                var result = response["rows"][0]["elements"][i];      
                if("OK".Equals(result["status"].Value<String>()))
                {
                    var time = new TravelTime();
                    time.DestinationAlias = destinations[i].Alias;
                    time.Time = result["duration"]["text"].Value<String>();
                    time.Distance = result["distance"]["text"].Value<String>();

                    times.Add(time);
                }
            }

            return times;
        }
    }
}
