using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Services.Dto
{
    public class CovidDataDto
    {
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Date { get; set; }
        public Province Provinces { get; set; }

    }

    public class Province
    {
        public string Name { get; set; }
        public string Confirmed { get; set; }
        public string Recovered { get; set; }
        public string Deaths { get; set; }
        public string Active { get; set; }
    }
}
