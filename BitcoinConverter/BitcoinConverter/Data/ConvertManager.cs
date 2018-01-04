using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BitcoinConverter.Data
{
    public class ConvertManager
    {
        private const string Url = "https://api.coindesk.com/v1/bpi/currentprice/";

        private static async Task<Currency> GetCurrency(string selectedCurrency)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync(Url + selectedCurrency + ".json");
            var bpiJObject = JObject.Parse(result).SelectToken("bpi") as JObject;
            var currency = bpiJObject.SelectToken(selectedCurrency);
            var response = currency.ToObject<Currency>();

            return response;
        }

        public static async Task<decimal> ConvertCurrency(string curr, decimal amount)
        {
            var currency = await GetCurrency(curr);
            var stringRate = currency.Rate;
            var rate = decimal.Parse(stringRate, NumberStyles.Currency, new CultureInfo("en-Us").NumberFormat);
            var result = rate * amount;
            return result;
        }
    }
}
