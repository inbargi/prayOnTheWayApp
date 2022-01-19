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
        AskMinyanDTO askM;
        [HttpPost]
        public bool AddAskMinyan(LocationPoint driverPoint)
        {
            long idPrayer = timeAlgorithmics.RecognizePrayer(driverPoint);
            if (idPrayer == -1)
            {
                //todo error1
                ErrorServiceClass.error = 1;
            }
            AskMinyanDTO askMinyan = new AskMinyanDTO
            {
                LocationPoint = driverPoint,
                IdPrayer = idPrayer,
                AskTime = DateTime.Now.TimeOfDay
            };
            if (!askMinyanBll.AddAskMinyan(askMinyan))
                return false;

            foreach (AskMinyanDTO askm in GetAskMinyans())
            {
                if ((askm.IdPrayer == idPrayer) &&
                    (askm.LocationPoint.Equals(driverPoint)) &&
                    (askm.AskTime.Equals(askMinyan.AskTime)))
                { askM = askm; }
            }
            if (askM != null)
                algorithmicPrayOnTheWay.Algorithmic(driverPoint, askM.IdAskMinyan);
            //todo not askMinyan
            return true;
        }
        public List<AskMinyanDTO> GetAskMinyans()
        {
            return askMinyanBll.GetAskMinyans();
        }
    }
}
