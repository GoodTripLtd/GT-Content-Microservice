using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Отримати категорію за назвою
        Task<Category?> GetByNameAsync(string name);
    }
}
