using CsvHelper;
using SharedObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class AirportService : IAirportService
    {
        private List<Airport> m_Airports = new List<Airport>();

        public void Configure(string DataPath)
        {
            using (var reader = new StreamReader(DataPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                m_Airports = csv.GetRecords<Airport>().ToList(); 
            }
        }

        // By design not efficent 
        public Airport GetAirport(string Code)
        {
            if(string.IsNullOrWhiteSpace(Code))
            {
                return null;
            }

            foreach(var airport in m_Airports)
            {
                if(Code.Equals(airport.IATA, StringComparison.CurrentCultureIgnoreCase) || Code.Equals(airport.ICAO, StringComparison.CurrentCultureIgnoreCase))
                {
                    return airport;
                }
            }
            return null;
        }

        // Hillariously not efficent 
        public Airport GetNearestAiport(double Latitude, double Longitude)
        {
            var coord = new Position
            {
                Latitude = Latitude,
                Longitude = Longitude
            };

            //var nearest = m_Airports.OrderBy(x => coord.GetDistanceTo(new GeoCoordinate(x.Lat, x.Long)));

            var nearestDistance = double.MaxValue;
            Airport nearest = null;
            var hv = new Haversine();

            foreach (var airport in m_Airports)
            {
                var currentCoord = new Position
                {
                    Latitude = airport.Lat,
                    Longitude = airport.Long
                };

                var distance = hv.Distance(coord, currentCoord, DistanceType.Miles);

                if (distance < nearestDistance)
                {
                    nearest = airport;
                    nearestDistance = distance;
                }
            }

            return nearest;
        }
    }
}
