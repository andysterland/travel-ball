using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class Utilities
    {
        public static int GetUnixTime(DateTime Date)
        {
            TimeSpan t = Date - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }
    }
}
