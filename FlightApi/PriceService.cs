using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class PriceService : IPriceService
    {
        public async Task<List<Price>> GetPrice(string DepartureAirportCode, string ArrivalAirportCode, DateTime Date)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Price>> GetPrice(IAirportService airportService, IFlightDestinationService flightService, string DepartureAirportCode, DateTime Date)
        {
            var date = DateTime.Now;
            var departureAirport = airportService.GetAirport(DepartureAirportCode);

            var destinations = await flightService.GetDestinationAirports(airportService, departureAirport.ICAO, date);

            var allPrices = new List<Price>();

            if (destinations == null || destinations.Count == 0)
            {
                return allPrices;
            }

            foreach (var dest in destinations)
            {
                var price = await GetPrice(departureAirport.ICAO, dest.ICAO, date);
                allPrices.AddRange(price);
            }

            return allPrices;
        }
    }
}
