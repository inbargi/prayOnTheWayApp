using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MinyanDTO
    {//ytry changing
        public long IDMinyan { get; set; }
        public long IDPrayer { get; set; }
        public DateTime DateMinyan { get; set; }
        public TimeSpan BeginningTimeNavToMinyan { get; set; }
        public long IDLocationMinyan { get; set; }
        public int NumOfPeopleInMinyan { get; set; }
        public bool SuccessfullyMinyan { get; set; }
    }
}
