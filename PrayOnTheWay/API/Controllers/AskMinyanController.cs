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
            //the location is sent to RecognizePrayer Function.
            long idPrayer = timeAlgorithmics.RecognizePrayer(driverPoint);
            if (idPrayer == -1)
            {
                idPrayer = 1;
                //if the recognize has a mistake it's will save an 1 error code 
                ErrorServiceClass.error = 1;

            }
            //saving askMinyan
            AskMinyanDTO askMinyan = new AskMinyanDTO
            {
                LocationPoint = driverPoint,
                IdPrayer = idPrayer,
                AskTime = DateTime.Now.TimeOfDay
            };
            long idAskMinyan = askMinyanBll.AddAskMinyan(askMinyan);
            ResultDTO r = algorithmicPrayOnTheWay.Algorithmic(driverPoint, idAskMinyan);
            r.IdAskMinyan = idAskMinyan;
            return r;
            
            //foreach (AskMinyanDTO askm in GetAskMinyans())
            //{
            //    if ((askm.IdPrayer == idPrayer) &&
            //        (askm.LocationPoint.Equals(driverPoint)) &&
            //        (askm.AskTime.Equals(askMinyan.AskTime)))
            //    { askM = askm; }
            //}
        }
        [HttpGet]
        public List<AskMinyanDTO> GetAskMinyans()
        {
            return askMinyanBll.GetAskMinyans();
        }
    }
}
