using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Services.Dto
{
    public class CovidDataDto
    {
        public string Country { get; set; }
        public double Latiude { get; set; }
        public double Longitude { get; set; }
        public string Date { get; set; }
        public Province Provinces { get; set; }

    }

    public class Province
    {
        public string Country { get; set; }
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public int Active { get; set; }
    }
}
