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
    public class PlaceTagRepository : GenericRepository<PlaceTag>, IPlaceTagRepository
    {
        public PlaceTagRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<PlaceTag>> GetByPlaceIdAsync(Guid placeId)
        {
            return await _context.PlaceTags
                                 .Where(pt => pt.PlaceId == placeId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<PlaceTag>> GetByTagIdAsync(Guid tagId)
        {
            return await _context.PlaceTags
                                 .Where(pt => pt.TagId == tagId)
                                 .ToListAsync();
        }
    }
}
