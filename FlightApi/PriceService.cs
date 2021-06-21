using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedObjects;

namespace FlightApi
{
    public class PriceService : IPriceService
    {
        private RandomPriceApiWrapper _randomPriceApiWrapper = new RandomPriceApiWrapper();
        public async Task<List<Price>> GetPrice(IAirportService airportService, string DepartureAirportCode, string ArrivalAirportCode, DateTime Date)
        {
            var allPrices = new List<Price>();
            var price = new Price();

            price.Departure = airportService.GetAirport(DepartureAirportCode);
            price.Destination = airportService.GetAirport(ArrivalAirportCode);
            price.PriceUsd = await _randomPriceApiWrapper.GetPrice(Date, DepartureAirportCode, ArrivalAirportCode);

            allPrices.Add(price);
            
            return allPrices;
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
                var price = await GetPrice(airportService, departureAirport.ICAO, dest.ICAO, date);
                allPrices.AddRange(price);
            }

            return allPrices;
        }
    }
}
