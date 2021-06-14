using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApi
{
    public class RandomPriceApiWrapper
    {
        private string _serviceUrl = "https://demoflightprice.azurewebsites.net/api/GetFlightPrice?date={0}&from={1}&to={2}";
        public async Task<double> GetPrice(DateTime Date, string FromIcao, string ToIcao)
        {
            var uri = string.Format(_serviceUrl, Date, FromIcao, ToIcao);

            using var client = new HttpClient();
            var response = await client.GetAsync(uri);
            var responseText = await response.Content.ReadAsStringAsync();

            var price = double.Parse(responseText);

            return price;            
        }
    }
}
