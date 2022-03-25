using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LocationPoint
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
       

        public override string ToString()
        {
            return Lat + ',' + Lng.ToString();
        }

    }
}
