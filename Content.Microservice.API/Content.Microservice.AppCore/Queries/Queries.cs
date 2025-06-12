using Content.Microservice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Microservice.AppCore.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>> { }
    public class GetCategoryByIdQuery : IRequest<Category?> { public Guid Id { get; set; } }

    public class GetAllPlacesQuery : IRequest<IEnumerable<Place>> { }
    public class GetPlaceByIdQuery : IRequest<Place?> { public Guid Id { get; set; } }

    public class GetAllRepliesQuery : IRequest<IEnumerable<Reply>> { }
    public class GetReplyByIdQuery : IRequest<Reply?> { public Guid Id { get; set; } }

    public class GetAllReviewsQuery : IRequest<IEnumerable<Review>> { }
    public class GetReviewByIdQuery : IRequest<Review?> { public Guid Id { get; set; } }

    public class GetAllTagsQuery : IRequest<IEnumerable<Tag>> { }
    public class GetTagByIdQuery : IRequest<Tag?> { public Guid Id { get; set; } }

    public class GetAllVotesQuery : IRequest<IEnumerable<Vote>> { }
    public class GetVoteByIdQuery : IRequest<Vote?> { public Guid Id { get; set; } }
}
