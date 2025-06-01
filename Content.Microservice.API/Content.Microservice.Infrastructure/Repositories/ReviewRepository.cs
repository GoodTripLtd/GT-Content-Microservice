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
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Review>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Reviews
                                 .Where(r => r.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetApprovedAsync()
        {
            return await _context.Reviews
                                 .Where(r => r.IsApproved)
                                 .ToListAsync();
        }
    }
}
