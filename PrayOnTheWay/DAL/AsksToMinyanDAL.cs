using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class AsksToMinyanDAL
    {
        public bool AddAsksToMinyan(AsksToMinyan askToMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.AsksToMinyans.Add(askToMinyan);
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
        public List<AsksToMinyan> GetAsksToMinyans()
        { 
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                return DB.AsksToMinyans.ToList();
            }
        }
        public bool UpdateAsksToMinyan(AsksToMinyan asksToMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Entry(asksToMinyan);
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
        public bool RemoveAsksToMinyan(AsksToMinyan asksToMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.AsksToMinyans.Remove(asksToMinyan);
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
