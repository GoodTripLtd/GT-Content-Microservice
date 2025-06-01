using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Guid UserId { get; set; }
        public UserSummary User { get; set; }
        public Guid PlaceId { get; set; }
        public Place Place { get; set; }
        public bool IsApproved { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public ICollection<Vote?> Votes { get; set; } = new List<Vote?>();
    }
}
