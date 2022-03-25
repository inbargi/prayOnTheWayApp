using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SafePointOnTheWayDAL
    {
        public long AddSafePointOnTheWay(SafePointOnTheWay safePointOnTheWay)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.SafePointOnTheWays.Add(safePointOnTheWay);
                try
                {
                    DB.SaveChanges();
                    return safePointOnTheWay.IdlocationMinyan;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
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
