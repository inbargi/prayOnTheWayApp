using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class TimeAtTheDayBLL
    {
        TimeAtTheDayDAL timeAtTheDayDAL = new TimeAtTheDayDAL();
        public bool AddTimeAtTheDay(TimeAtTheDayDTO timeAtTheDay)
        {

            return timeAtTheDayDAL.AddTimeAtTheDay(Converts.TimeAtTheDayConvert.ConvertDTOToDAL(timeAtTheDay));
        }
        public List<TimeAtTheDayDTO> GetTimeAtTheDays()
        {
            return Converts.TimeAtTheDayConvert.ConvertDALToDTOList(timeAtTheDayDAL.GetTimeAtTheDays());
        }
        public bool UpdateTimeAtTheDay(TimeAtTheDayDTO timeAtTheDay)
        {
            return timeAtTheDayDAL.UpdateTimeAtTheDay(Converts.TimeAtTheDayConvert.ConvertDTOToDAL(timeAtTheDay));
        }
        public bool RemoveTimeAtTheDay(TimeAtTheDayDTO timeAtTheDay)
        {
            return timeAtTheDayDAL.RemoveTimeAtTheDay(Converts.TimeAtTheDayConvert.ConvertDTOToDAL(timeAtTheDay));
        }
    }
}
