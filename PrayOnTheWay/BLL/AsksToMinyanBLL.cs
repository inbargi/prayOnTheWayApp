using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AsksToMinyanBLL
    {
        AsksToMinyanDAL asksToMinyanDAL = new AsksToMinyanDAL();
        public bool AddAsksToMinyan(AsksToMinyanDTO AsksToMinyan)
        {

            return asksToMinyanDAL.AddAsksToMinyan(Converts.AsksToMinyanConvert.ConvertDTOToDAL(AsksToMinyan));
        }
        public List<AsksToMinyanDTO> GetAsksToMinyans()
        {
            return Converts.AsksToMinyanConvert.ConvertDALToDTOList(asksToMinyanDAL.GetAsksToMinyans());
        }
        public bool UpdateAsksToMinyan(AsksToMinyanDTO asksToMinyan)
        {
            return asksToMinyanDAL.UpdateAsksToMinyan(Converts.AsksToMinyanConvert.ConvertDTOToDAL(asksToMinyan));
        }
        public bool RemoveAsksToMinyan(AsksToMinyanDTO asksToMinyan)
        {
            return asksToMinyanDAL.RemoveAsksToMinyan(Converts.AsksToMinyanConvert.ConvertDTOToDAL(asksToMinyan));
        }

        public long GetIdMinyanByIdAskMinyan(long idAskMinyan)
        {
            List<AsksToMinyanDTO> asksToMinyans = GetAsksToMinyans();
            long idMinyan = -1;
            foreach (AsksToMinyanDTO askto in asksToMinyans)
            {
                if (askto.IdAskMinyan == idAskMinyan)
                    idMinyan = askto.IdMinyan;
            }
            return idMinyan;
        }
    }
}
