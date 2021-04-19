using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Repositories.CovidRepository
{
    public class CovidDataRepository
    {
        private readonly AppDbContext _context;
        public CovidDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable GetAll()
        {
            return _context.Nations.AsQueryable();
        }

    }
}
