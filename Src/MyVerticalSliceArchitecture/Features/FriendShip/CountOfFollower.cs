using MediatR;
using MyVerticalSliceArchitecture.Data;

namespace MyVerticalSliceArchitecture.Features.FriendShip;

public static class CountOfFollower
{
    public static void AddEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/FriendShip/CountOfFollower", async (CountFollowerQuery request, ISender sender) =>
        {
            var id = await sender.Send(request);

            return Results.Ok(id);
        });
    }
}

public class CountFollowerQuery : IRequest<Int64>
{
    public Int64 UserId { get; set; }
}

internal class CountFollowerHandler : IRequestHandler<CountFollowerQuery, Int64>
{
    private readonly AppDbContext _dbContext;

    public CountFollowerHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Int64> Handle(CountFollowerQuery request, CancellationToken cancellationToken)
    {
        Int64 count = _dbContext.UserRelations.Where(x => x.UserId == request.UserId).Count();
        return Task.FromResult(count);
    }

}
