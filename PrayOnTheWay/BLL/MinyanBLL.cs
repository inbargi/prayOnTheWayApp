using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

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
        public bool UpdateMinyan(MinyanDTO minyan)
        {
            return minyanDAL.UpdateMinyan(Converts.MinyanConvert.ConvertDTOToDAL(minyan));
        }
        public bool RemoveMinyan(MinyanDTO minyan)
        {
            return minyanDAL.RemoveMinyan(Converts.MinyanConvert.ConvertDTOToDAL(minyan));
        }
    }
}
