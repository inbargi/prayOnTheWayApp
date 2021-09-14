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
        public double Lat { get; set; }
        public double Lng { get; set; }
        public long IdPrayer { get; set; }
        public long AskTime { get; set; }

        public  PrayerDTO Prayer { get; set; }
        public  List<AsksToMinyanDTO> AsksToMinyans { get; set; }
    }
}
