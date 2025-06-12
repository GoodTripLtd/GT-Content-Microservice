using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class PlaceCategory : BaseEntity
    {
        public Guid PlaceId { get; set; }
        public Guid CategoryId { get; set; }
        public Place Place { get; set; }
        public Category Category { get; set; }
    }
}
