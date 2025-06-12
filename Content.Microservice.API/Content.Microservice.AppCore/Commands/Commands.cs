using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.AppCore.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
    }
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CreatePlaceCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class UpdatePlaceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Guid CategoryId { get; set; }
    }
    public class DeletePlaceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CreateReplyCommand : IRequest<Guid>
    {
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid? ReviewId { get; set; }
        public Guid? ParentReplyId { get; set; }
    }
    public class UpdateReplyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
    }
    public class DeleteReplyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CreateReviewCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid PlaceId { get; set; }
        public bool IsApproved { get; set; }
        public string PhotoUrl { get; set; } = null!;
    }
    public class UpdateReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public string PhotoUrl { get; set; } = null!;
    }
    public class DeleteReviewCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CreateTagCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
    }
    public class UpdateTagCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class DeleteTagCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CreateVoteCommand : IRequest<Guid>
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public bool Value { get; set; }
    }
    public class UpdateVoteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public bool Value { get; set; }
    }
    public class DeleteVoteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
