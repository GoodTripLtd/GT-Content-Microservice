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
    public class TripPlanRepository : GenericRepository<TripPlan>, ITripPlanRepository
    {
        public TripPlanRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<TripPlan>> GetByUserIdAsync(Guid userId)
        {
            return await _context.TripPlans
                                 .Where(tp => tp.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<TripPlan>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _context.TripPlans
                                 .Where(tp => tp.StartDate >= start && tp.EndDate <= end)
                                 .ToListAsync();
        }
    }
}
