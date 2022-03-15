using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SelectResult
    {
        public long IdAskMinyan { get; set; }
        public List<SelectMinyan> SelectMinyan { get; set; }
        public int IdSelect { get; set; }
    }
}
