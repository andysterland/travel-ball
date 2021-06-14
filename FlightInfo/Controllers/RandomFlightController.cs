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
    public class RandomFlightController : Controller
    {
        private readonly IFlightDestinationService _flightService;
        private readonly IAirportService _airportService;
        private readonly IPriceService _priceService;
        private readonly ILogger _logger;

        public RandomFlightController(ILogger<RandomFlightController> logger,
            IFlightDestinationService flightService,
            IAirportService airportService,
            IPriceService priceService)
        {
            _logger = logger;
            _flightService = flightService;
            _airportService = airportService;
            _priceService = priceService;
        }

        [HttpGet("{DepatureIcao}")]
        public async Task<IActionResult> GetRandomFlight(string DepatureIcao)
        {
            var allPrices = await _priceService.GetPrice(_airportService, _flightService, DepatureIcao, DateTime.Now);

            if (allPrices == null || allPrices.Count == 0)
            {
                NotFound();
            }

            var random = new Random();
            int index = random.Next(allPrices.Count);
            return Ok(allPrices[index]);
        }
    }
}
