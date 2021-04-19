using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Services
{
    public interface ICovidDataService
    {
        Task CovidDailyReportAllCountries();
        Task CovidDailyReportByCountry(string country);
    }
}
