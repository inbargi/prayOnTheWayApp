using BLL;
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
    [RoutePrefix("api/manager")]
    public class ManagerController : ApiController
    {
        ManagerBLL managerBll = new ManagerBLL();
        [HttpGet]
        [Route("{userName}/{password}")]
        public bool LoginManager(string userName, string password)
        {
            return managerBll.LoginManager(userName, password);
        }
    }
}
