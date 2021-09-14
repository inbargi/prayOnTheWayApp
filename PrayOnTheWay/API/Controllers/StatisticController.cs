using BLL;
using DTO.StatisticDTO;
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
    public class StatisticController : ApiController
    {
        StatisticBLL statisticBLL = new StatisticBLL();
        [HttpGet]
        public StatisticDataDTO[] DataToStatisticPrayer()
        {
            return statisticBLL.DataToStatisticPrayer();
        }
        public StatisticDataDTO[]  DataToStatisticSuccessfullyMinyan()
        {
            return statisticBLL.DataToStatisticSuccessfullyMinyan();
        }
        public StatisticDataDTO[] DataToStatisticCreateTime()
        {
            return statisticBLL.DataToStatisticCreateTime();
        }
    }
}
