using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface ITripPlanRepository : IGenericRepository<TripPlan>
    {
        Task<IEnumerable<TripPlan>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<TripPlan>> GetByDateRangeAsync(DateTime start, DateTime end);
    }
}
