using FlightApi;
using FlightObjectModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : Controller
    {
        private readonly IFlightDestinationService _flightService;
        private readonly IAirportService _airportService;
        private readonly ILogger _logger;

        public DestinationController(ILogger<DestinationController> logger, IFlightDestinationService flightService, IAirportService airportService)
        {
            _logger = logger;
            _flightService = flightService;
            _airportService = airportService;
        }

        // GET: api/Departur/LHR

        [HttpGet("{ICAO}", Name = "Get")]
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
