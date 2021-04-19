using FeedAPI.Repositories.CovidRepository;
using FeedAPI.Services.CovidDataService;
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
        public readonly ICovidDataRepository _repo;
        public CovidDataController(ICovidDataService service, ICovidDataRepository repo)
        {
            _service = service;
            _repo = repo;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var data = _repo.GetAll();
            return Ok(data);
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
