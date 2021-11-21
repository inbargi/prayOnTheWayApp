using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BLL;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*","*","*")]
    public class MinyanController : ApiController
    {
        MinyanBLL minyanBll = new MinyanBLL();

        public bool Addminyan(MinyanDTO minyan)
        {
            return minyanBll.AddMinyan(minyan);

        }
        public List<MinyanDTO> Getminyans()
        {
            new BLL.LocationAlgorithmics().FindOptionalLocations(new LocationPoint { Lat= "31.8701568", Lng= "34.7406336" });
            new BLL.LocationAlgorithmics().RouteDistanceInSecondOnModeDrive(new LocationPoint { Lat = "31.8701568", Lng = "34.7406336" }, new LocationPoint { Lat = "269.8701568", Lng = "270.7406336" });
            return minyanBll.GetMinyans();
        }
    }
}
