using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface IPlaceTagRepository : IGenericRepository<PlaceTag>
    {
        Task<IEnumerable<PlaceTag>> GetByPlaceIdAsync(Guid placeId);
        Task<IEnumerable<PlaceTag>> GetByTagIdAsync(Guid tagId);
    }
}
