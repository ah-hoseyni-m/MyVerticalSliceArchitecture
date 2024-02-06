using MediatR;
using MyVerticalSliceArchitecture.Data;

namespace MyVerticalSliceArchitecture.Features.FriendShip;

public static class CountOfFollower
{
    //public static void AddEndPoint(this IEndpointRouteBuilder app)
    //{
    //    //app.MapGet("/api/FriendShip/CountOfFollower", async (Query request, ISender sender) =>
    //    //{
    //    //    var id = await sender.Send(request);
    //    //    return Results.Ok(id);
    //    //});

    //}
    public static void AddEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/FriendShip/CountOfFollower", async (Query request, ISender sender) =>
        {
            var id = await sender.Send(request);

            //return Results.Ok(id);
        });
    }
}

public class Query : IRequest<Int64>
{
    public Int64 UserId { get; set; }
}
//public record Query(Int64 UserId) : IRequest<Int64>;

internal class CountFollowerHandler : IRequestHandler<Query , Int64>
{
    private readonly AppDbContext _dbContext;

    public CountFollowerHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Int64> Handle(Query request, CancellationToken cancellationToken)
    {
        Int64 count = _dbContext.UserRelations.Where(x => x.UserId == request.UserId).Count();
        return Task.FromResult(count);
    }

}
