using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using DTO;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AskMinyanController : ApiController
    {
        AskMinyanBLL askMinyanBll = new AskMinyanBLL();

        public bool AddAskMinyan(AskMinyanDTO askMinyan)
        {
            return askMinyanBll.AddAskMinyan(askMinyan);

        }
        public List<AskMinyanDTO> GetAskMinyans()
        {
            return askMinyanBll.GetAskMinyans();
        }
    }
}
