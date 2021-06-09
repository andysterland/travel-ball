using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class OpenSkyDepatureAirport
    {
        public string icao24 { get; set; }
        public int firstSeen { get; set; }
        public string estDepartureAirport { get; set; }
        public int lastSeen { get; set; }
        public string estArrivalAirport { get; set; }
        public string callsign { get; set; }
        public int estDepartureAirportHorizDistance { get; set; }
        public int estDepartureAirportVertDistance { get; set; }
        public int? estArrivalAirportHorizDistance { get; set; }
        public int? estArrivalAirportVertDistance { get; set; }
        public int departureAirportCandidatesCount { get; set; }
        public int arrivalAirportCandidatesCount { get; set; }
    }
}
