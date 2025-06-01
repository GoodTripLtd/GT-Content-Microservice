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
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Vote>> GetByReviewIdAsync(Guid reviewId)
        {
            return await _context.Votes
                                 .Where(v => v.ReviewId == reviewId)
                                 .ToListAsync();
        }

        public async Task<Vote?> GetByReviewAndUserAsync(Guid reviewId, Guid userId)
        {
            return await _context.Votes
                                 .FirstOrDefaultAsync(v => v.ReviewId == reviewId && v.UserId == userId);
        }
    }
}
