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
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Photo>> GetByReviewIdAsync(Guid reviewId)
        {
            return await _context.Photos
                                 .Where(p => p.ReviewId == reviewId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetByReplyIdAsync(Guid replyId)
        {
            return await _context.Photos
                                 .Where(p => p.ReplyId == replyId)
                                 .ToListAsync();
        }
    }
}
