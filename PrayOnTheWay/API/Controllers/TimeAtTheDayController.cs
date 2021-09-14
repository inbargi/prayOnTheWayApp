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
    public class TimeAtTheDayController : ApiController
    {
        TimeAtTheDayBLL timeAtTheDayBll = new TimeAtTheDayBLL();

        public bool AddtimeAtTheDay(TimeAtTheDayDTO timeAtTheDay)
        {
            return timeAtTheDayBll.AddTimeAtTheDay(timeAtTheDay);

        }
        public List<TimeAtTheDayDTO> GettimeAtTheDays()
        {
            return timeAtTheDayBll.GetTimeAtTheDays();
        }
    }
}
