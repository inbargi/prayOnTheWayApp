using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class PrayerDTO
    {
        public long IdPrayer { get; set; }
        public string NamePrayer { get; set; }
        public long IdTime { get; set; }
        public long LastTimeToday { get; set; }
        public long PrayTimeLength { get; set; }
        public List<AskMinyanDTO> AskMinyans { get; set; }
        public TimeAtTheDayDTO TimeAtTheDay { get; set; }
    }
}

