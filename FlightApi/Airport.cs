using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
