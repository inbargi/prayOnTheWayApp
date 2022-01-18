using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class MinyanDAL
    {

        public bool AddMinyan(Minyan minyan)
        {
            using (PrayOnTheWayEntities DB=new PrayOnTheWayEntities())
            {
                DB.Minyans.Add(minyan);
                try
                {
                    DB.SaveChanges();
                    return true;
                }
                catch (Exception )
                {
                    throw;
                }
            }
       
        }
        public List<Minyan> GetMinyans()
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
              return  DB.Minyans.ToList();
            }
        }
        public bool UpdateMinyan(Minyan minyan)
        {
            using(PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Entry(minyan);
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
        public bool RemoveMinyan(Minyan minyan)
        {
            using(PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Minyans.Remove(minyan);
                try
                { 
                    DB.SaveChanges(); 
                    return true;
                }
                catch(Exception)
                {
                    throw;
                }
            }
           
        }
    }
}
