using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class TimeAtTheDayDAL
    {
        public bool AddTimeAtTheDay(TimeAtTheDay timeAtTheDay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.TimeAtTheDays.Add(timeAtTheDay);
                try
                {
                    DB.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }
        public List<TimeAtTheDay> GetTimeAtTheDays()
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                return DB.TimeAtTheDays.ToList();
            }
        }
        public bool UpdateTimeAtTheDay(TimeAtTheDay timeAtTheDay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Entry(timeAtTheDay);
                try
                {
                    DB.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }
        public bool RemoveTimeAtTheDay(TimeAtTheDay TimeAtTheDay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.TimeAtTheDays.Remove(TimeAtTheDay);
                try
                {
                    DB.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
           
        }
    }
}
