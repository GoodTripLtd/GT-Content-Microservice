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
    public class UserSummaryRepository : GenericRepository<UserSummary>, IUserSummaryRepository
    {
        public UserSummaryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<UserSummary?> GetByUserNameAsync(string userName)
        {
            return await _context.UserSummaries
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
