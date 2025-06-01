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
    public class TripItemRepository : GenericRepository<TripItem>, ITripItemRepository
    {
        public TripItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<TripItem>> GetByTripPlanIdAsync(Guid tripPlanId)
        {
            return await _context.TripItems
                                 .Where(ti => ti.TripPlanId == tripPlanId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<TripItem>> GetOrderedByDisplayOrderAsync(Guid tripPlanId)
        {
            return await _context.TripItems
                                 .Where(ti => ti.TripPlanId == tripPlanId)
                                 .OrderBy(ti => ti.DisplayOrder)
                                 .ToListAsync();
        }
    }
}
