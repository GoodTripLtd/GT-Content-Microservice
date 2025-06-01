using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface IReplyRepository : IGenericRepository<Reply>
    {
        Task<IEnumerable<Reply>> GetByReviewIdAsync(Guid reviewId);
        Task<IEnumerable<Reply>> GetChildRepliesAsync(Guid parentReplyId);
    }
}
