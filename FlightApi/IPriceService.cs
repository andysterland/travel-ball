using SharedObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightApi
{
    public interface IPriceService
    {
        public Task<List<Price>> GetPrice(IAirportService airportService, string DepartureAirportCode, string ArrivalAirportCode, DateTime Date);
        public Task<List<Price>> GetPrice(IAirportService airportService, IFlightDestinationService flightService, string DepartureAirportCode, DateTime Date);
    }
}
