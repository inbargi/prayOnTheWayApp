using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SelectMinyan
    {
        public long IdMinyan { get; set; }
        public int NumKM { get; set; }
        public int NumOfPeople { get; set; }
        public int TimeDriver { get; set; }
        public int PercentSuccess { get; set; }
    }
}
