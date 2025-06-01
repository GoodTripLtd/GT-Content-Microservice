using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class TripItem: BaseEntity
    {
        public Guid TripPlanId { get; set; }
        public TripPlan TripPlan { get; set; }
        public Guid PlaceId { get; set; }
        public Place Place { get; set; }
        public string Notes { get; set; }
        public int DisplayOrder { get; set; }
    }
}
