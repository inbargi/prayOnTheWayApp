using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Algoritmics
{
    public class MinyanAlgorithmics
    {
        public List<OptionalLocation> SearchMatchMinyan(LocationPoint driverLocation)
        {
            List<OptionalLocation> list = new List<OptionalLocation>();
            return list;
        }
        public void AddPrayerToMinyan(int idMinyan)
        {
           
        }
        public void RemovePrayerToMinyan(int idMinyan)
        {
           
        }
        public int NumOfPeopleInMinyan()
        {
            return 1;
        }
        public bool  IsMinyanActive()
        {
            return NumOfPeopleInMinyan() != 0;
        }
        public int MinyansInPercent()
        {
            return 1;
        }
        public void SavingChoose(int idMinyan)
        {

        }

    }
}
