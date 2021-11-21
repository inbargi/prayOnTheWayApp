using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class AskMinyanDTO
    {
        public long IdAskMinyan { get; set; }
       
        public long IdPrayer { get; set; }
        public TimeSpan AskTime { get; set; }
        public LocationPoint LocationPoint { get; set; }

        public  PrayerDTO Prayer { get; set; }
        public  List<AsksToMinyanDTO> AsksToMinyans { get; set; }
    }
}
