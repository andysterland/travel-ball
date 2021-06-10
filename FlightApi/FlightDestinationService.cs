using FlightObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightApi
{
    public class FlightDestinationService : IFlightDestinationService
    {
        private OpenSkyWrapper _opensky;

        public FlightDestinationService()
        {

        }

        public void Configure(string User, string Password)
        {
            if(string.IsNullOrEmpty(User))
            {
                throw new ArgumentNullException(nameof(User));
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentNullException(nameof(Password));
            }

            _opensky = new OpenSkyWrapper(User, Password);
        }

        public async Task<List<Airport>> GetDestinationAirports(IAirportService AirportService, string AirportCode, DateTime Date)
        {
            var airportCodes = await _opensky.GetDestinationAirports(AirportCode, Date);

            var airports = new List<Airport>();

            foreach (var airportCode in airportCodes)
            {
                var airport = AirportService.GetAirport(airportCode);
                if (airport != null)
                {
                    airports.Add(airport);
                }
            }

            return airports;
        }
    }
}
