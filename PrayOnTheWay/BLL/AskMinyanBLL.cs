using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AskMinyanBLL
    {
        AskMinyanDAL askMinyanDAL = new AskMinyanDAL();
        List<AskMinyanDTO> asksMinyan = new List<AskMinyanDTO>();
        //statistics
       
        /*public void */

        public long AddAskMinyan(AskMinyanDTO AskMinyan)
        {
            //todo Check what prayer
            return askMinyanDAL.AddAskMinyan(Converts.AskMinyanConvert.ConvertDTOToDAL(AskMinyan));
            //calculate options
        }
        public List<AskMinyanDTO> GetAskMinyans()
        {
            return Converts.AskMinyanConvert.ConvertDALToDTOList(askMinyanDAL.GetAskMinyans());
        }
        public bool UpdateAskMinyan(AskMinyanDTO askMinyan)
        {
            return askMinyanDAL.UpdateAskMinyan(Converts.AskMinyanConvert.ConvertDTOToDAL(askMinyan));
        }
        public bool RemoveAskMinyan(AskMinyanDTO askMinyan)
        {
            return askMinyanDAL.RemoveAskMinyan(Converts.AskMinyanConvert.ConvertDTOToDAL(askMinyan));
        }
        
        
       
    }
}
