using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PrayerBll
    {
        PrayerDAL prayerDAL = new PrayerDAL();
        public bool AddPrayer(PrayerDTO Prayer)
        {

            return prayerDAL.AddPrayer(Converts.PrayerConvert.ConvertDTOToDAL(Prayer));
        }
        public List<PrayerDTO> GetPrayers()
        {
            return Converts.PrayerConvert.ConvertDALToDTOList(prayerDAL.GetPrayers());
        }
        public bool UpdatePrayer(PrayerDTO prayer)
        {
            return prayerDAL.UpdatePrayer(Converts.PrayerConvert.ConvertDTOToDAL(prayer));
        }
        public bool RemovePrayer(PrayerDTO prayer)
        {
            return prayerDAL.RemovePrayer(Converts.PrayerConvert.ConvertDTOToDAL(prayer));
        }
    }
}
