using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Algoritmics
{
    public class AlgorithmicPrayOnTheWay
    {
        //todo checking if the post in askMinyan return type askm
        MinyanAlgorithmics minyanAlgorithmics = new MinyanAlgorithmics();
        TimeAlgorithmics timeAlgorithmics = new TimeAlgorithmics();
        LocationAlgorithmics locationAlgorithmics = new LocationAlgorithmics();
        MinyanBLL minyanBLL = new MinyanBLL();

        public ResultDTO Algorithmic(LocationPoint driverLocation, long idAskMinyan)
        {
            //AsksToMinyanDTO asksToMinyan =
            return minyanAlgorithmics.DriverOptions(driverLocation, idAskMinyan);
            //List<MinyanDTO> minyans = minyanBLL.GetMinyans();
            //long idDestinantion = -1;
            //foreach (MinyanDTO m in minyans)
            //{
            //    if (m.IDMinyan == asksToMinyan.IdMinyan)
            //    {
            //        idDestinantion = m.IDLocationMinyan;
            //    }
            //}
            //LocationPoint destination = locationAlgorithmics.GetLocationByIDMinyan(idDestinantion);
            //if (destination.Lat == null || destination.Lng == null)
            //{
            //    //todo error3
            //    ErrorServiceClass.error = 3;
            //}
            //if (timeAlgorithmics.CheckTimeAlgorithmic(driverLocation, destination))
            //{
            //}//todo navigation

            //return true;
        }
    }
}
