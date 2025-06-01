using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class PlaceTag : BaseEntity
    {
        public Guid PlaceId { get; set; }
        public Guid TagId { get; set; }
        public Place Place { get; set; }
        public Tag Tag { get; set; }
    }
}
