using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Models
{
    public class Nation
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Date { get; set; }
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
