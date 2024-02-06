using MediatR;
using MyVerticalSliceArchitecture.Data;
using MyVerticalSliceArchitecture.Entities;

namespace MyVerticalSliceArchitecture.Features.FriendShip;

public static class Follow
{
    public static void AddEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/FriendShip/Follow", async (FollowFriendShipCommand request, ISender sender) =>
        {
            var id = await sender.Send(request);
            return Results.Ok(id);
        });
    }
}

public record FollowFriendShipCommand(Int64 UserId, Int64 FollowId) : IRequest<Int64>;

internal class Handler : IRequestHandler<FollowFriendShipCommand, Int64>
{
    private readonly AppDbContext _appDbContext;

    public Handler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<long> Handle(FollowFriendShipCommand request, CancellationToken cancellationToken)
    {
        var uRelations = new UserRelations
        {
            UserId = request.UserId,
            FollowUserId = request.FollowId,
            CreateAt = DateTime.UtcNow
        };

        _appDbContext.UserRelations.Add(uRelations);

        _appDbContext.SaveChanges();

        return Task.FromResult(uRelations.Id);
    }
}