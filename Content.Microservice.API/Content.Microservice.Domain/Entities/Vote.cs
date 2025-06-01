using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class Vote: BaseEntity
    {
        public Guid ReviewId { get; set; }
        public Review? Review { get; set; } = null!;
        public Guid UserId { get; set; }
        public bool Value { get; set; }
        public DateTime VotedAt { get; set; }
    }
}
