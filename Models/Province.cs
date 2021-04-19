using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Confirmed { get; set; }
        public string Recovered { get; set; }
        public string Deaths { get; set; }
        public string Active { get; set; }
        public int CountryId { get; set; }
        public virtual Nation Country { get; set; }
    }
}
