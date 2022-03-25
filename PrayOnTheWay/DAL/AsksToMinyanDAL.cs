using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace DAL
{
    public class AsksToMinyanDAL
    {
        public long AddAsksToMinyan(AsksToMinyan askToMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.AsksToMinyans.Add(askToMinyan);
                try
                {
                    DB.SaveChanges();
                    return askToMinyan.IdAsksToMinyan;
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
        public List<AsksToMinyan> GetAsksToMinyans()
        { 
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                return DB.AsksToMinyans.Include(d => d.AskMinyan).Include(d=>d.Minyan).ToList();
            }
        }
        public bool UpdateAsksToMinyan(AsksToMinyan asksToMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                AsksToMinyan asktominyan = DB.AsksToMinyans.FirstOrDefault(a => a.IdAsksToMinyan == asksToMinyan.IdAsksToMinyan);
                asktominyan.IsComming =asksToMinyan.IsComming ;
                asktominyan.Message = asktominyan.Message;
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
