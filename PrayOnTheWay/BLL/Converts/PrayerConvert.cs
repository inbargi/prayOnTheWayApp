using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Converts
{
    public class PrayerConvert
    {
        public static PrayerDTO ConvertDALToDTO(Prayer prayer)
        {
            return new PrayerDTO
            {
                IdPrayer = prayer.IdPrayer,
                IdTime = prayer.IdTime,
                NamePrayer = prayer.NamePrayer,
                LastTimeToday = prayer.LastTimeToday,
             //   TimeAtTheDay = TimeAtTheDayConvert.ConvertDALToDTO(prayer.TimeAtTheDay),
               // AskMinyans = AskMinyanConvert.ConvertDALToDTOList(prayer.AskMinyans)
            };
        }
        public static Prayer ConvertDTOToDAL(PrayerDTO prayerDTO)
        {
            return new Prayer
            {
                IdPrayer = prayerDTO.IdPrayer,
                IdTime = prayerDTO.IdTime,
                NamePrayer = prayerDTO.NamePrayer,
                LastTimeToday = prayerDTO.LastTimeToday,
             //   TimeAtTheDay = TimeAtTheDayConvert.ConvertDTOToDAL(prayerDTO.TimeAtTheDay),
               // AskMinyans = AskMinyanConvert.ConvertDTOToDALList(prayerDTO.AskMinyans)

            };

        }
        public static List<PrayerDTO> ConvertDALToDTOList(ICollection<Prayer> prayers)
        {
            return prayers.Select(p => ConvertDALToDTO(p)).ToList();
        }
        public static ICollection<Prayer> ConvertDTOToDALList(List<PrayerDTO> prayers)
        {
            return prayers.Select(p => ConvertDTOToDAL(p)).ToList();
        }
    }
}

