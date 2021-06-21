using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects
{
    public class Price
    {
        public Airport Destination { get; set; }
        public Airport Departure { get; set; }
        public double PriceUsd { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string FlightCode { get; set; }
        public string Airline { get; set; }
    }
}
