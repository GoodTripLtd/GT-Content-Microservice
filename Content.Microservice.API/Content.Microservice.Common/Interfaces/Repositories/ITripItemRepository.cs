using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface ITripItemRepository : IGenericRepository<TripItem>
    {
        Task<IEnumerable<TripItem>> GetByTripPlanIdAsync(Guid tripPlanId);
        Task<IEnumerable<TripItem>> GetOrderedByDisplayOrderAsync(Guid tripPlanId);
    }
}
