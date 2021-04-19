using FeedAPI.Helper;
using FeedAPI.Services.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeedAPI.Services.CovidDataService
{
    public class CovidDataService: ICovidDataService
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

        public async Task<List<CovidDataDto>> DailyReportByCountry(string countryName)
        {
            var countryToCamel = System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(countryName);
            var result = new List<CovidDataDto>();
            var today = dates.Now.ToString("yyyy-MM-dd");
            string urlData = $"{countryToCamel}?date={today}";
            var finalUrl = DataUrl + urlData;
            var client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(finalUrl),
                Headers =
                {
                    { "x-rapidapi-key", RapidApiKey },
                    { "x-rapidapi-host", RapidHost },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = (JObject)JsonConvert.DeserializeObject(body);
                var country = json["country"].Value<JObject>().ToString();
                var latitude = json["latitude"].Value<JObject>().ToString();
                var longiude = json["longitude"].Value<JObject>().ToString();
                var date = json["date"].Value<JObject>().ToString();
                var province = json["province"].Value<JObject>();
                var nation = province["country"].Value<JObject>().ToString();
                var confirmed = province["confirmed"].Value<JObject>().ToString();
                var recovered = province["recovered"].Value<JObject>().ToString();
                var deaths = province["deaths"].Value<JObject>().ToString();
                var active = province["active"].Value<JObject>().ToString();

                result.Add(new CovidDataDto()
                {
                    Country = country,
                    Latitude = latitude,
                    Longitude = longiude,
                    Provinces = new Province()
                    {
                        Name = nation,
                        Confirmed = confirmed,
                        Recovered = recovered,
                        Deaths = deaths,
                        Active = active
                    }
                });
                return result;
            }
        }

        public async Task<List<CovidDataDto>> DailyReportAllCountries()
        {
            var result = new List<CovidDataDto>();
            var today = dates.Now.ToString("yyyy-MM-dd");
            string urlData = $"all?date={today}";
            var finalUrl = DataUrl + urlData;
            var client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(finalUrl),
                Headers =
                {
                    { "x-rapidapi-key", RapidApiKey },
                    { "x-rapidapi-host", RapidHost },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = (JObject)JsonConvert.DeserializeObject(body);
                var country = json["country"].Value<JObject>().ToString();
                var latitude = json["latitude"].Value<JObject>().ToString();
                var longiude = json["longitude"].Value<JObject>().ToString();
                var date = json["date"].Value<JObject>().ToString();
                var province = json["province"].Value<JObject>();
                var nation = province["country"].Value<JObject>().ToString();
                var confirmed = province["confirmed"].Value<JObject>().ToString();
                var recovered = province["recovered"].Value<JObject>().ToString();
                var deaths = province["deaths"].Value<JObject>().ToString();
                var active = province["active"].Value<JObject>().ToString();

                result.Add(new CovidDataDto()
                {
                    Country = country,
                    Latitude = latitude,
                    Longitude = longiude,
                    Provinces = new Province()
                    {
                        Name = nation,
                        Confirmed = confirmed,
                        Recovered = recovered,
                        Deaths = deaths,
                        Active = active
                    }
                });
                return result;
            }     
        }
    }
}
