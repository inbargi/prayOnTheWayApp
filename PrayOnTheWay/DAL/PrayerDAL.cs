using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DAL
{
    public class PrayerDAL
    {
        public bool AddPrayer(Prayer prayer)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Prayers.Add(prayer);
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
        public List<Prayer> GetPrayers()
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                return DB.Prayers.Include(p=>p.AskMinyans).Include(p=>p.TimeAtTheDay).ToList();
            }
        }
        public bool UpdatePrayer(Prayer prayer)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Entry(prayer);
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
        public bool RemovePrayer(Prayer prayer)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Prayers.Remove(prayer);
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
