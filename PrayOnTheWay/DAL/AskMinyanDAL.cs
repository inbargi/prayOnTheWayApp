using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class AskMinyanDAL
    {

        public bool AddAskMinyan(AskMinyan askMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.AskMinyans.Add(askMinyan);
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
        public List<AskMinyan> GetAskMinyans()
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                return DB.AskMinyans.ToList();
            }
        }
        public bool UpdateAskMinyan(AskMinyan askMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.Entry(askMinyan);
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
        public bool RemoveAskMinyan(AskMinyan askMinyan)
        {
            using (PrayOnTheWayEntities DB = new PrayOnTheWayEntities())
            {
                DB.AskMinyans.Remove(askMinyan);
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
