using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.Domain.Entities
{
    public class Reply : BaseEntity
    {
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
        public UserSummary User { get; set; }
        public Guid? ReviewId { get; set; }
        public Review? Review { get; set; }
        public Guid? ParentReplyId { get; set; }
        public Reply? ParentReply { get; set; }
        public ICollection<Reply> ChildReplies { get; set; } = new List<Reply>();
        public ICollection<Photo> Photos { get; set; }
    }
}
