using FlightApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FlightInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : Controller
    {
        private readonly IFlightDestinationService _flightService;
        private readonly IAirportService _airportService;
        private readonly IPriceService _priceService;
        private readonly ILogger _logger;

        public DestinationController(ILogger<DestinationController> logger, 
            IFlightDestinationService flightService, 
            IAirportService airportService,
            IPriceService priceService)
        {
            _logger = logger;
            _flightService = flightService;
            _airportService = airportService;
            _priceService = priceService;
        }

        // GET: api/Departur/LHR

        [HttpGet("{ICAO}", Name = "GetDestinations")]
        public async Task<IActionResult> GetDestinationsAsync(string ICAO)
        {
            var airports = await _flightService.GetDestinationAirports(_airportService, ICAO, DateTime.Now);

            if(airports == null || airports.Count == 0)
            {
                return NotFound();
            }

            return Ok(airports);
        }
    }
}
