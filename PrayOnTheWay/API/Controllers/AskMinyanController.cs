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
        public bool AddAskMinyan(LocationPoint driverPoint)
        {
            long idPrayer = timeAlgorithmics.RecognizePrayer(driverPoint);
            if(idPrayer == -1)
            {
                //todo send to angular message-not time for pray
            }
             
               
            AskMinyanDTO askMinyan = new AskMinyanDTO {
                LocationPoint = driverPoint ,
                IdPrayer=idPrayer,
                AskTime=DateTime.Now.TimeOfDay
            };
            algorithmicPrayOnTheWay.Algorithmic(driverPoint, askMinyan.IdAskMinyan);
            return askMinyanBll.AddAskMinyan(askMinyan);


        }
        public List<AskMinyanDTO> GetAskMinyans()
        {
            return askMinyanBll.GetAskMinyans();
        }
    }
}
