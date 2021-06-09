using FlightObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public interface IFlightDestinationService
    {
        public Task<List<string>> GetDestinationAirports(string AirportCode);
        public Task<List<string>> GetDestinationAirports(string AirportCode, DateTime Date);
        public void Configure(string User, string Pass);
    }
}
