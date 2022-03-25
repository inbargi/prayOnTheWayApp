using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class MinyanDAL
    {
        public long AddMinyan(Minyan minyan)
        {
            using (PrayOnTheWayEntities DB=new PrayOnTheWayEntities())
            {
                DB.Minyans.Add(minyan);
                try
                {
                    DB.SaveChanges();
                    return minyan.IdMinyan;
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.InnerException.InnerException.Message);
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
                Minyan minyan1 = DB.Minyans.FirstOrDefault(u => u.IdMinyan == minyan.IdMinyan);
                minyan1.NumOfPeopleInMinyan = minyan.NumOfPeopleInMinyan;
                minyan1.SuccessfullyMinyan = minyan.SuccessfullyMinyan;

                //DB.Entry(minyan);
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
