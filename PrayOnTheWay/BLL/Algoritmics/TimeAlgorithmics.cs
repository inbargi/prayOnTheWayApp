using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TimeAlgorithmics
    {
        public double DriverSpeed()
        {
            return 80.0;
        }
        public TimeSpan GetEnterTime()
        {
            return new TimeSpan();
        }
        public TimeSpan TimeUntillEndTimePray(LocationPoint currentLocation)
        {
            return new TimeSpan();
        }
        public double TimeDriveToMinyan()
        {
            return 0;
        }
        public bool IsOver18Mins()
        {
            return TimeDriveToMinyan() < 1080;
        }
        public int RecognizePrayer()
        {
            return 1;
        }
        public bool CheckTimeAlgorithmic(int idPrayer)
        {
            return true;
        }

    }
}
