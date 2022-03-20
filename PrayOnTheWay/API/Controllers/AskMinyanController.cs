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
    public class AskMinyanController : ApiController
    {
        AskMinyanBLL askMinyanBll = new AskMinyanBLL();
        TimeAlgorithmics timeAlgorithmics = new TimeAlgorithmics();
        AlgorithmicPrayOnTheWay algorithmicPrayOnTheWay = new AlgorithmicPrayOnTheWay();
        [HttpPost]
        public ResultDTO AddAskMinyan(LocationPoint driverPoint)
        {
            ResultDTO r=new ResultDTO();
            //the location is sent to RecognizePrayer Function.
            long idPrayer = timeAlgorithmics.RecognizePrayer(driverPoint);
            
            if (idPrayer == -1)
            {
                //if the recognize has a mistake it's will save an 1 error code 
                ErrorServiceClass.error = 1;
                r.Error = 1;
                return r;
            }
            //saving askMinyan
            AskMinyanDTO askMinyan = new AskMinyanDTO
            {
                LocationPoint = driverPoint,
                IdPrayer = idPrayer,
                AskTime = DateTime.Now.TimeOfDay
            };
            long idAskMinyan = askMinyanBll.AddAskMinyan(askMinyan);
            r = algorithmicPrayOnTheWay.Algorithmic(driverPoint, idAskMinyan);
            r.IdAskMinyan = idAskMinyan;
            return r;
        }
        [HttpPost]
        public AskMinyanDTO GetAskMinyan([FromBody]long idAskMinyan)
        {
            if (idAskMinyan <= 0)
                return null;
            return askMinyanBll.GetAskMinyan(idAskMinyan);
        }
        [HttpGet]
        public List<AskMinyanDTO> GetAskMinyans()
        {
            return askMinyanBll.GetAskMinyans();
        }
    }
}

