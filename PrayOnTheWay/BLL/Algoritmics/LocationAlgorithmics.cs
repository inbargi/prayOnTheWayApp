using BLL.Models;
using DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class LocationAlgorithmics
    {
        public const double R = 2700; //1800 * (18/60)
        AskMinyanBLL askMinyanBLL = new AskMinyanBLL();
        SafePointOnTheWayBLL safePointOnTheWayBLL = new SafePointOnTheWayBLL();
        public LocationPoint DriverLocation(int idAskMinyan)
        {
            LocationPoint l = new LocationPoint();
            List<AskMinyanDTO> asks = askMinyanBLL.GetAskMinyans();
            foreach (var ask in asks)
            {
                if(ask.IdAskMinyan == idAskMinyan)
                {
                    l= ask.LocationPoint;
                }
            }
            return l;
        }
        public LocationPoint GetLocationByIDMinyan(long idLocationMinyan)
        {
            LocationPoint point = new LocationPoint();
            List<SafePointOnTheWayDTO> safesPointOnTheWay = safePointOnTheWayBLL.GetSafePointOnTheWays();
            foreach (var safe in safesPointOnTheWay)
            {
                if (safe.IdlocationMinyan == idLocationMinyan)
                {
                    point.Lat = safe.Lat;
                    point.Lng = safe.Lng;
                    break;
                }
            }
            return point;
        }

        public int RouteDistanceInSecondOnModeDrive(LocationPoint current, LocationPoint destination)
        {
            string ApiKey = ConfigurationManager.AppSettings["APIKEY"];
            string uri = $"https://maps.googleapis.com/maps/api/distancematrix/xml?key={ApiKey}&origins={current.ToString()}&destinations={destination.ToString()}&mode=driving";
            var client = new RestClient(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            XDocument xmlResult = XDocument.Parse(response.Content);
            int timeInSecond = ConvertXmlToSecond(xmlResult);
            return timeInSecond;
        }

        public List<OptionalLocation> FindOptionalLocations(LocationPoint point)
        {
            string ApiKey = ConfigurationManager.AppSettings["APIKEY"];
            string uri = $"https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location={point.ToString()}&radius={R}&types=gas_station&key={ApiKey}";
            var client = new RestClient(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            List<OptionalLocation> s = new List<OptionalLocation>();

            XDocument xmlResult = XDocument.Parse(response.Content);
            s=ConvertXmlToList(xmlResult);
            
            return s;
        }
        public int RouteDistanceInKMOnModeDrive(LocationPoint current, LocationPoint destination)
        {
            string ApiKey = ConfigurationManager.AppSettings["APIKEY"];
            string uri = $"https://maps.googleapis.com/maps/api/distancematrix/xml?key={ApiKey}&origins={current.ToString()}&destinations={destination.ToString()}&mode=driving";
            var client = new RestClient(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            XDocument xmlResult = XDocument.Parse(response.Content);
            int timeInKM = ConvertXmlToKM(xmlResult);
            return timeInKM / 1000;
        }
        public List<OptionalLocation> ConvertXmlToList(XDocument xmlResult)
        {
            List<OptionalLocation> s = new List<OptionalLocation>();
            if (xmlResult.Root.Element("status").Value != "ok" && xmlResult.Root.Element("status").Value != "OK")
                return s;
            foreach (var res in xmlResult.Root.Elements("result"))
            {
                XElement location = res.Element("geometry").Element("location");
                s.Add(new OptionalLocation
                {
                    LocationName = res.Element("name").Value + " " +
                    res.Element("vicinity").Value,
                    Point =
                    new LocationPoint
                    {
                        Lat = location.Element("lat").Value,
                        Lng = location.Element("lng").Value
                    }
                });
            }
            return s;
        }
        public int ConvertXmlToSecond(XDocument xmlResult)
        {
            
            if (xmlResult.Root.Element("status").Value == "ok" || xmlResult.Root.Element("status").Value == "OK")
            { 
                XElement res = xmlResult.Root.Element("row").Element("element");
                if(res.Element("status").Value == "ok" || res.Element("status").Value == "OK")
                {
                    return Convert.ToInt32(res.Element("duration").Element("value").Value);
                }
            }
            return 0;
        }
        public int ConvertXmlToKM(XDocument xmlResult)
        {

            if (xmlResult.Root.Element("status").Value == "ok" || xmlResult.Root.Element("status").Value == "OK")
            {
                XElement res = xmlResult.Root.Element("row").Element("element");
                if (res.Element("status").Value == "ok" || res.Element("status").Value == "OK")
                {
                    return Convert.ToInt32(res.Element("distance").Element("value").Value);
                }
            }
            return 0;
        }
    }
}
