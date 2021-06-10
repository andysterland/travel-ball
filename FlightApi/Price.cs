using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class Price
    {
        public Airport Destination;
        public Airport Departure;
        public double PriceUsd;
        public DateTime DepartureDate;
        public DateTime ArrivalDate;
        public string FlightCode;
        public string Airline;
    }
}
