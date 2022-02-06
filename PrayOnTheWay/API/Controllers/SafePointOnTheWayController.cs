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
    public class SafePointOnTheWayController : ApiController
    {
        SafePointOnTheWayBLL safePointOnTheWayBll = new SafePointOnTheWayBLL();
        [HttpPost]
        public long AddSafePointOnTheWay(SafePointOnTheWayDTO safePointOnTheWay)
        {
            return safePointOnTheWayBll.AddSafePointOnTheWay(safePointOnTheWay);
        }
        [HttpGet]
        public List<SafePointOnTheWayDTO> GetSafePointOnTheWays()
        {
            return safePointOnTheWayBll.GetSafePointOnTheWays();
        }
    }
}
