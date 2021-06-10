using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public interface IAirportService
    {
        public void Configure(string DataPath);
        Airport GetAirport(string Code);
    }
}
