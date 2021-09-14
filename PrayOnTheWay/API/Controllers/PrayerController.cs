using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]

    public class PrayerController : ApiController
    {
        PrayerBll prayerBll = new PrayerBll();

        public bool AddPrayer(PrayerDTO prayer)
        {
            return prayerBll.AddPrayer(prayer);
            
        }
        public List<PrayerDTO> GetPrayers()
        {
            return prayerBll.GetPrayers();
        }
    }
}
