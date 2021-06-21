using FlightApi;
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
    public class DepartureController : Controller
    {
        private readonly IFlightDestinationService _flightService;
        private readonly IAirportService _airportService;
        private readonly IPriceService _priceService;
        private readonly ILogger _logger;

        public DepartureController(ILogger<DepartureController> logger,
            IFlightDestinationService flightService,
            IAirportService airportService,
            IPriceService priceService)
        {
            _logger = logger;
            _flightService = flightService;
            _airportService = airportService;
            _priceService = priceService;
        }


        [HttpGet]
        public async Task<IActionResult> GetNearestAirport(double Lat, double Long)
        {
            var airports = _airportService.GetNearestAiport(Lat, Long);

            if (airports == null)
            {
                return NotFound();
            }

            return Ok(airports);
        }
    }
}
