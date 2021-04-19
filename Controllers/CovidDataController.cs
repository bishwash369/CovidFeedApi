using FeedAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Controllers
{
    [Route("api/[Controller]")]
    public class CovidDataController: ControllerBase
    {
        public readonly ICovidDataService _service;
        public CovidDataController(ICovidDataService service)
        {
            _service = service;
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetReportAllCountries()
        {
            var data = await _service.DailyReportAllCountries();
            return Ok(data);
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetReportByCountry(string country)
        {
            var data = await _service.DailyReportByCountry(country);
            return Ok(data);
        }


    }
}
