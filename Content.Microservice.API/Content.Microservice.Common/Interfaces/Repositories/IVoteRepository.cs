using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface IVoteRepository : IGenericRepository<Vote>
    {
        Task<IEnumerable<Vote>> GetByReviewIdAsync(Guid reviewId);
        Task<Vote?> GetByReviewAndUserAsync(Guid reviewId, Guid userId);
    }
}
