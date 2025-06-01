using Content.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Common.Interfaces.Repositories
{
    public interface IPlaceRepository : IGenericRepository<Place>
    {
        Task<IEnumerable<Place>> GetByNameAsync(string name);
        Task<IEnumerable<Place>> GetByLocationAsync(decimal latitude, decimal longitude, double radiusKm);
    }
}
