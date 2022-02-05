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
        //zmanim פונקציה מתאימה על פי
        public string SuitableFunc { get; set; }

        public List<PrayerDTO> Prayers { get; set; }

    }
}
