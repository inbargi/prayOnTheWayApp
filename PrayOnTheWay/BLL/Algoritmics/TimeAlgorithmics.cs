using DTO;
using GeoTimeZone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zmanim;
using Zmanim.TimeZone;
using Zmanim.TzDatebase;
using Zmanim.Utilities;
using TzLookup;
using TimeZoneLookup = TzLookup.TimeZoneLookup;

namespace BLL
{
    public class TimeAlgorithmics
    {
        TimeAtTheDayBLL timeAtTheDayBLL = new TimeAtTheDayBLL();
        AskMinyanBLL askMinyanBLL = new AskMinyanBLL();
        PrayerBll prayerBll = new PrayerBll();
        LocationAlgorithmics locationAlgorithmics = new LocationAlgorithmics();
        

        public double DriverSpeed()
        {
            return 80.0;
        }
        public TimeSpan GetEnterTime(long idAskMinyan)
        {
            List<AskMinyanDTO> asks = askMinyanBLL.GetAskMinyans();
            foreach(AskMinyanDTO ask  in asks)
            {
                if(ask.IdAskMinyan == idAskMinyan)
                {
                    return ask.AskTime;
                }
            }
            return new TimeSpan();
        }
        public TimeSpan TimeUntillEndTimePray(LocationPoint driverPoint)
        {
            long idPrayer = RecognizePrayer(driverPoint);
            List<PrayerDTO> prayers = prayerBll.GetPrayers();
            foreach (PrayerDTO pray in prayers)
            {
                if (pray.IdPrayer == idPrayer)
                {
                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                    TimeSpan lastTime = GetTimeByTimeFunc(pray.LastTimeToday, driverPoint);
                    return lastTime - currentTime;
                }
            }
            return new TimeSpan();
        }
        public TimeSpan GetEndTimePray(LocationPoint driverPoint)
        {
            long idPrayer = RecognizePrayer(driverPoint);
            List<PrayerDTO> prayers = prayerBll.GetPrayers();
            foreach (PrayerDTO pray in prayers)
            {
                if (pray.IdPrayer == idPrayer)
                {
                    return GetTimeByTimeFunc(pray.LastTimeToday, driverPoint);
                }
            }
            return new TimeSpan();
        }

        public int TimeDriveToMinyan(LocationPoint driverLocation, LocationPoint destination)
        {
            return locationAlgorithmics.RouteDistanceInSecondOnModeDrive(driverLocation, destination);
        }
        public bool IsOver18Mins(LocationPoint driverLocation, LocationPoint destination)
        {
            return TimeDriveToMinyan(driverLocation, destination) < 1080;
        }
        public int GetPrayLength(int idPrayer)
        {
            
            List<PrayerDTO> prayers = prayerBll.GetPrayers();
            foreach (PrayerDTO pray in prayers)
            {
                if (pray.IdPrayer == idPrayer)
                {
                    return (int)pray.PrayTimeLength;
                }
            }
            return -1;
        }
        public long RecognizePrayer(LocationPoint driverPoint)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            List<PrayerDTO> prayers = prayerBll.GetPrayers();
            foreach (PrayerDTO pray in prayers)
            {
                TimeSpan beginingTime = GetTimeByTimeFunc(pray.IdTime, driverPoint);
                TimeSpan lastTime = GetTimeByTimeFunc(pray.LastTimeToday, driverPoint);
                if(currentTime >= beginingTime && currentTime <= lastTime)
                {
                    return pray.IdPrayer;
                }
            }
            return -1;
        }
        public string GetSuitableFunc(long idTime)
        {
            string suitFunc = "";
            List<TimeAtTheDayDTO> times = timeAtTheDayBLL.GetTimeAtTheDays();
            foreach (TimeAtTheDayDTO tim in times)
            {
                if (tim.IdTime == idTime)
                {
                    suitFunc = tim.SuitableFunc;
                    break;
                }
            }
            return suitFunc;
        }
        public TimeSpan GetTimeByTimeFunc(long idTime, LocationPoint driverPoint)
        {
            //todo checking to this func
            //LocationPoint driveLocationPoint = locationAlgorithmics.DriverLocation(idAskMinyan);
            string timeZoneString = TimeZoneLookup.Iana((float)Convert.ToDouble(driverPoint.Lat), (float)Convert.ToDouble(driverPoint.Lng));

            ITimeZone timeZone = new OlsonTimeZone(timeZoneString);
            GeoLocation location = new GeoLocation((float)Convert.ToDouble(driverPoint.Lat), (float)Convert.ToDouble( driverPoint.Lng), timeZone);

            ComplexZmanimCalendar zc = new ComplexZmanimCalendar(location);

            var method = typeof(ComplexZmanimCalendar).GetMethod(GetSuitableFunc(idTime));
            DateTime result = (DateTime)method.Invoke(zc, new object[] { });
            return result.TimeOfDay;
        }
        public bool CheckTimeAlgorithmic(LocationPoint driverLocation, LocationPoint destination)
        {
            int currentTime = (int)DateTime.Now.TimeOfDay.TotalSeconds;
            int navigationTime = TimeDriveToMinyan(driverLocation, destination);
            int prayTimeLength = GetPrayLength((int)RecognizePrayer(driverLocation))*60;
            int getEndTimePray = (int)GetEndTimePray(driverLocation).TotalSeconds;
            if (navigationTime == 0 || prayTimeLength == -1 || getEndTimePray.Equals(new TimeSpan()))
                return false;
            if(currentTime + navigationTime + prayTimeLength > getEndTimePray)
                return false;
            return true;
        }

    }
}
