using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class ResultDTO
    {
        public AsksToMinyanDTO AsksToMinyanDTO { get; set; }
        public long IdAskMinyan { get; set; }
        public List<SelectMinyan> SelectMinyan { get; set; }
        public int Error { get; set; }
        public LocationPoint Origin { get; set; }
        public LocationPoint Destination { get; set; }
    }
}
