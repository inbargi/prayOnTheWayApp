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
        public string Lat { get; set; }
        public string Lng { get; set; }

        public List<MinyanDTO> Minyans { get; set; }
    }
}
