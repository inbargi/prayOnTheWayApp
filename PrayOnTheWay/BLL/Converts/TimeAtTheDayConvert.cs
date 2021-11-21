using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL.Converts
{
    public class TimeAtTheDayConvert
    {
        public static TimeAtTheDayDTO ConvertDALToDTO(TimeAtTheDay timeAtTheDay)
        {
            return new TimeAtTheDayDTO
            {
                IdTime = timeAtTheDay.IdTime,
                Descreption = timeAtTheDay.Descreption,
                SuitableFunc = timeAtTheDay.SuitableFunc
                // Prayers = PrayerConvert.ConvertDALToDTOList(timeAtTheDay.Prayers)

            };
        }

        public static TimeAtTheDay ConvertDTOToDAL(TimeAtTheDayDTO timeAtTheDayDTO)
        {
            return new TimeAtTheDay
            {
                IdTime = timeAtTheDayDTO.IdTime,
                Descreption = timeAtTheDayDTO.Descreption,
                SuitableFunc = timeAtTheDayDTO.SuitableFunc

                //  Prayers = PrayerConvert.ConvertDTOToDALList(timeAtTheDayDTO.Prayers)

            };
        }
        public static List<TimeAtTheDayDTO> ConvertDALToDTOList(ICollection<TimeAtTheDay> timeAtTheWays)
        {
            return timeAtTheWays.Select(m => ConvertDALToDTO(m)).ToList();
        }
        public static ICollection<TimeAtTheDay> ConvertDTOToDALList(List<TimeAtTheDayDTO> timeAtTheWays)
        {
            return timeAtTheWays.Select(m => ConvertDTOToDAL(m)).ToList();
        }

    }
}
