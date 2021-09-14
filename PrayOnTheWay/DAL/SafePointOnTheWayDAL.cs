using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SafePointOnTheWayDAL
    {
        public bool AddSafePointOnTheWay(SafePointOnTheWay safePointOnTheWay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.SafePointOnTheWays.Add(safePointOnTheWay);
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
        public List<SafePointOnTheWay> GetSafePointOnTheWays()
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                return DB.SafePointOnTheWays.ToList();
            }
        }
        public bool UpdateSafePointOnTheWay(SafePointOnTheWay safePointOnTheWay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Entry(safePointOnTheWay);
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
        public bool RemoveSafePointOnTheWay(SafePointOnTheWay safePointOnTheWay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.SafePointOnTheWays.Remove(safePointOnTheWay);
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
