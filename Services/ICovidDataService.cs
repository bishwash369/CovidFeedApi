using FeedAPI.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Services
{
    public interface ICovidDataService
    {
        Task<List<CovidDataDto>> DailyReportAllCountries();
        Task<List<CovidDataDto>> DailyReportByCountry(string country);
    }
}
