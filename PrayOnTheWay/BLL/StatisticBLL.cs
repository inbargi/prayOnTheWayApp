using DAL;
using DTO.StatisticDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class StatisticBLL
    {
        PrayerDAL prayerDAL = new PrayerDAL();
        public StatisticDataDTO[] DataToStatisticPrayer()
        {
            return prayerDAL.GetPrayers().Select(p => new StatisticDataDTO { name = p.NamePrayer, value = p.AskMinyans.Count }).ToArray();
        }

        //מניין בוצע בהצלחה
        //חישוב של מניינים המסומנים כבוצעו בהצלחה
        MinyanDAL minyanDAL = new MinyanDAL();

        public StatisticDataDTO[] DataToStatisticSuccessfullyMinyan()
        {
            StatisticDataDTO[] successfullyMinyanStatistic = new StatisticDataDTO[2];
            successfullyMinyanStatistic[0] = new StatisticDataDTO { name = "  לא התקיים", value = 0 };
            successfullyMinyanStatistic[1] = new StatisticDataDTO { name = "  התקיים", value = 0 };
            foreach (Minyan m in minyanDAL.GetMinyans())
            {
                successfullyMinyanStatistic[Convert.ToInt32(m.SuccessfullyMinyan)].value++;
            }
            return successfullyMinyanStatistic;
        }
        //זמן יצירת מניין
        //חישוב ובדיקה של הנתונים 
        //השמה למערך על פי סיפרת העשרות
        public StatisticDataDTO[] DataToStatisticCreateTime()
        {
            StatisticDataDTO[] createTimeMinyanStatistic = new StatisticDataDTO[4];
            createTimeMinyanStatistic[0] = new StatisticDataDTO { name = "0-10", value = 0 };
            createTimeMinyanStatistic[1] = new StatisticDataDTO { name = "10-20", value = 0 };
            createTimeMinyanStatistic[2] = new StatisticDataDTO { name = "20-30", value = 0 };
            createTimeMinyanStatistic[3] = new StatisticDataDTO { name = "30+", value = 0 };
            foreach(Minyan m in minyanDAL.GetMinyans())
            {
                int timeInMinutes = (int)(m.BeginningTimeNavToMinyan - m.DateMinyan.TimeOfDay).TotalMinutes;
                    //(m.BeginningTimeNavToMinyan.Hours - m.DateMinyan.TimeOfDay.Hours) * 60 + (m.BeginningTimeNavToMinyan.Minutes - m.DateMinyan.TimeOfDay.Minutes);
                if (timeInMinutes > 30)
                    createTimeMinyanStatistic[3].value++;
                else
                    createTimeMinyanStatistic[timeInMinutes / 10].value++;
            }
            return createTimeMinyanStatistic;
        }
        
    }
}
