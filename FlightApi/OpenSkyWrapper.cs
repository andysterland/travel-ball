using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightApi
{
    public class OpenSkyWrapper
    {
        private string _user;
        private string _password;
        private string _baseUri;
        private string _departureEndPoint = "{0}/api/flights/departure?airport={1}&begin={2}&end={3}";

        public OpenSkyWrapper(string User, string Password)
        {
            if (string.IsNullOrEmpty(User))
            {
                throw new ArgumentNullException(nameof(User));
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentNullException(nameof(Password));
            }

            _user = User;
            _password = Password;
            _baseUri = string.Format("https://{0}:{1}@opensky-network.org", _user, _password);
        }

        public async Task<List<string>> GetDestinationAirports(string AirportCode, DateTime Date)
        {
            var StartDate = Date.AddDays(-7);
            var EndDate = StartDate.AddDays(1);

            var uri = string.Format(_departureEndPoint, _baseUri, AirportCode, Utilities.GetUnixTime(StartDate), Utilities.GetUnixTime(EndDate));

            using var client = new HttpClient();
            var response = await client.GetAsync(uri);
            var responseText = await response.Content.ReadAsStringAsync();

            var airports = JsonSerializer.Deserialize<OpenSkyDepatureAirport[]>(responseText);

            var result = new Dictionary<string, string>();

            foreach (var airport in airports)
            {
                if (!string.IsNullOrEmpty(airport.estArrivalAirport) && !result.ContainsKey(airport.estArrivalAirport))
                {
                    result.Add(airport.estArrivalAirport, airport.estArrivalAirport);
                }
            }

            return result.Keys.ToList();
        }
    }
}
