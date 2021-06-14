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
    public class PriceController : Controller
    {
        private readonly IFlightDestinationService _flightService;
        private readonly IAirportService _airportService;
        private readonly IPriceService _priceService;
        private readonly ILogger _logger;

        public PriceController(ILogger<PriceController> logger,
            IFlightDestinationService flightService,
            IAirportService airportService,
            IPriceService priceService)
        {
            _logger = logger;
            _flightService = flightService;
            _airportService = airportService;
            _priceService = priceService;
        }

        [HttpGet("{DepartureICAO}")]
        public async Task<IActionResult> Get(string DepartureICAO)
        {
            var date = DateTime.Now;
            var allPrices = await _priceService.GetPrice(_airportService, _flightService, DepartureICAO, date);

            if(allPrices == null || allPrices.Count == 0)
            {
                NotFound();
            }

            return Ok(allPrices);
        }
    }
}
