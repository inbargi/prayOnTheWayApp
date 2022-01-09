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
        MinyanAlgorithmics minyanAlgorithmics = new MinyanAlgorithmics();
        TimeAlgorithmics timeAlgorithmics = new TimeAlgorithmics();
        LocationAlgorithmics locationAlgorithmics = new LocationAlgorithmics();
        MinyanBLL minyanBLL = new MinyanBLL();
        
        public bool Algorithmic(LocationPoint driverLocation, long idAskMinyan)
        { 
            AsksToMinyanDTO asksToMinyan = minyanAlgorithmics.DriverOptions(driverLocation, idAskMinyan);
            List<MinyanDTO> minyans = minyanBLL.GetMinyans();
            long idDestinantion=-1;
            foreach (MinyanDTO m in minyans)
            {
                if(m.IDMinyan == asksToMinyan.IdMinyan)
                {
                    idDestinantion = m.IDLocationMinyan;
                }
            }
            LocationPoint destination = locationAlgorithmics.GetLocationByIDMinyan(idDestinantion);
            if (destination.Lat == null || destination.Lng == null)
                //todo messeage location not valid
                if (timeAlgorithmics.CheckTimeAlgorithmic(driverLocation, destination))

                    return true;




            return true; 
        }
    }
}
