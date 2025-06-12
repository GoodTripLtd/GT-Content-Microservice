using Content.Microservice.Common.Interfaces.Repositories;
using Content.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Infrastructure.Repositories
{
    public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
    {
        public PlaceRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Place>> GetByNameAsync(string name)
        {
            return await _context.Places
                                 .Where(p => p.Name.Contains(name))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Place>> GetByLocationAsync(
            decimal latitude,
            decimal longitude,
            double radiusKm)
        {
            var delta = (decimal)(radiusKm / 111.0);
            var minLat = latitude - delta;
            var maxLat = latitude + delta;
            var minLon = longitude - delta;
            var maxLon = longitude + delta;

            return await _context.Places
                                 .Where(p =>
                                     p.Latitude >= minLat && p.Latitude <= maxLat &&
                                     p.Longitude >= minLon && p.Longitude <= maxLon)
                                 .ToListAsync();
        }
    }
}
