using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SafePointOnTheWayDTO
    {
        public long IdlocationMinyan { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public List<MinyanDTO> Minyans { get; set; }
    }
}
