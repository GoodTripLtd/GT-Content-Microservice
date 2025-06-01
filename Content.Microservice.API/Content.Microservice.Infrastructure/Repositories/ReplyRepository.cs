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
    public class ReplyRepository : GenericRepository<Reply>, IReplyRepository
    {
        public ReplyRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Reply>> GetByReviewIdAsync(Guid reviewId)
        {
            return await _context.Replies
                                 .Where(rp => rp.ReviewId == reviewId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Reply>> GetChildRepliesAsync(Guid parentReplyId)
        {
            return await _context.Replies
                                 .Where(rp => rp.ParentReplyId == parentReplyId)
                                 .ToListAsync();
        }
    }
}
