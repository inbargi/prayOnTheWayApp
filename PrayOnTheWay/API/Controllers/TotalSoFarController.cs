using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;
using BLL.Algoritmics;
using DTO;
namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TotalSoFarController : ApiController
    {
        AsksToMinyanBLL asksToMinyanBLL = new AsksToMinyanBLL();
        MinyanAlgorithmics minyanAlgorithmics = new MinyanAlgorithmics();

        [HttpGet]
        public int GetTotalSoFar(long idAskMinyan)
        { 
            return minyanAlgorithmics.NumOfPeopleInMinyan(asksToMinyanBLL.GetIdMinyanByIdAskMinyan(idAskMinyan));
        }
    }
}
