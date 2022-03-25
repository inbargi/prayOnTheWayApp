using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AsksToMinyanDTO
    {
        public long IdAsksToMinyan { get; set; }
        public long IdAskMinyan { get; set; }
        public long IdMinyan { get; set; }
        public bool IsComming { get; set; }
        public string Message { get; set; }

        public AskMinyanDTO AskMinyan { get; set; }
        public MinyanDTO Minyan { get; set; }
    }
}
