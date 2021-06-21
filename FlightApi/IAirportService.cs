using SharedObjects;
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
        public Airport GetAirport(string Code);
        public Airport GetNearestAiport(double Latitude, double Longitude);
    }
}
