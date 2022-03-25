using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BLL.Algoritmics;

namespace BLL
{
    public class MinyanBLL
    {
        MinyanDAL minyanDAL = new MinyanDAL();
       

        public long AddMinyan(MinyanDTO minyan)
        {
            return minyanDAL.AddMinyan(Converts.MinyanConvert.ConvertDTOToDAL(minyan));
        }
        public List<MinyanDTO> GetMinyans()
        {
            return Converts.MinyanConvert.ConvertDALToDTOList(minyanDAL.GetMinyans());
        }
        public void ExitFromMinyan(long idMinyan)
        {
            MinyanAlgorithmics minyanAlgorithmics = new MinyanAlgorithmics();
            minyanAlgorithmics.RemovePrayerFromMinyan(idMinyan);
        }
        public bool UpdateMinyan(MinyanDTO minyan)
        {

            return minyanDAL.UpdateMinyan(Converts.MinyanConvert.ConvertDTOToDAL(minyan));
        }
        public bool UpdateSuccessfullyMinyan(long idMinyan)
        {

            Minyan minyan = minyanDAL.GetMinyans().Find(m => m.IdMinyan == idMinyan);
            return minyanDAL.UpdateMinyan(minyan);
        }

        public bool RemoveMinyan(MinyanDTO minyan)
        {
            return minyanDAL.RemoveMinyan(Converts.MinyanConvert.ConvertDTOToDAL(minyan));
        }
    }
}
