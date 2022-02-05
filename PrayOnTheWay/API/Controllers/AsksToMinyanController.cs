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
    public class AsksToMinyanController : ApiController
    {
       AsksToMinyanBLL asksToMinyanBll = new AsksToMinyanBLL();
        [HttpPost]
        public bool AddAsksToMinyan(AsksToMinyanDTO asksToMinyan)
        {
            return asksToMinyanBll.AddAsksToMinyan(asksToMinyan);
        }
        [HttpGet]
        public List<AsksToMinyanDTO> GetAsksToMinyans()
        {
            return asksToMinyanBll.GetAsksToMinyans();
        }
    }
}
