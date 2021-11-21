using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TimeAtTheDayDTO
    {
        public long IdTime { get; set; }
        public string Descreption { get; set; }
        public string SuitableFunc { get; set; }
        //להוסיף פןנקציה מתאימה
        public List<PrayerDTO> Prayers { get; set; }

    }
}
