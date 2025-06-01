using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string PhotoUrl { get; set; }
        public Guid? ReviewId { get; set; }
        public Review? Review { get; set; }
        public Guid? ReplyId { get; set; }
        public Reply? Reply { get; set; }
    }
}
