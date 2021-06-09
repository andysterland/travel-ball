using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightObjectModel
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
    }
}
