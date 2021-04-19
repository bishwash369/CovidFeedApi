using FeedAPI.Helper;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Threading.Tasks;

namespace FeedAPI.Services
{
    public class CovidDataService:ICovidDataService
    {
        public readonly string DataUrl;
        public readonly string RapidApiKey;
        public readonly string RapidHost;
        private readonly DatesDto dates = new DatesDto();

        public CovidDataService(IConfiguration configuration)
        {
            DataUrl = configuration.GetValue<string>("DataUrl");
            RapidApiKey = configuration.GetValue<string>("RapidApiKey");
            RapidHost = configuration.GetValue<string>("RapidHost");
        }

        public async Task CovidDailyReportByCountry(string country)
        {
            var countryToCamel = System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(country);
            var today = dates.TodayStart.Date;
            string data = $"name?date={today}&name={countryToCamel}";;
            var finalUrl = DataUrl + data;
            var client = new RestClient(finalUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", RapidApiKey);
            request.AddHeader("x-rapidapi-host", RapidHost);
            IRestResponse response = client.Execute(request);
        }

        public async Task CovidDailyReportAllCountries()
        {
            var client = new RestClient("https://covid-19-data.p.rapidapi.com/report/country/all?date=2020-04-01");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "e7efc1d8f3mshb9b356f590d069ep1fa3d4jsn82ebaa0523c3");
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
        }
    }
}
