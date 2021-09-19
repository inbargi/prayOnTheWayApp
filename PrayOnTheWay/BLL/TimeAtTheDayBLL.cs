using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zmanim;
using Zmanim.TimeZone;
using Zmanim.Utilities;
using Zmanim.TzDatebase; 
 using TzLookup;

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

        public TimeSpan GetTimeOfDay(TimeAtTheDay timeAtTheDay, double latitude,double longitude)
        {
           //
             latitude = 40.09596; //Lakewood, NJ
             longitude = -74.22213; //Lakewood, NJ
            string timeZoneString = TimeZoneLookup.Iana((float)latitude, (float)longitude);

            ITimeZone timeZone = new OlsonTimeZone(timeZoneString);
            GeoLocation location = new GeoLocation(latitude, longitude,timeZone);
            ComplexZmanimCalendar zc = new ComplexZmanimCalendar(location);
            //optionally set it to a specific date with a year, month and day
            //ComplexZmanimCalendar zc = new ComplexZmanimCalendar(new DateTime(1969, 2, 8), location);


          var method = typeof(ComplexZmanimCalendar).GetMethod("GetMethodNameFromDB");
          DateTime result= (DateTime)method.Invoke(zc, new object[] { });
          return result.TimeOfDay;

        }
    }
}
