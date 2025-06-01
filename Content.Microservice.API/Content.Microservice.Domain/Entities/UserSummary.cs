using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class UserSummary : BaseEntity
    {
        public string UserName { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public ICollection<TripPlan> TripPlans { get; set; } = new List<TripPlan>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
