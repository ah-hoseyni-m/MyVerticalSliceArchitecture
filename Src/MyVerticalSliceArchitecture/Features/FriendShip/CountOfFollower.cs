using MediatR;
using MyVerticalSliceArchitecture.Data;
using MyVerticalSliceArchitecture.Entities;

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
        app.MapPost("api/FriendShip/CountOfFollower", async (CountFollowerQuery request, ISender sender) =>
        {
            var id = await sender.Send(request.Id);

            return Results.Ok(id);
        });
    }
}

public class CountFollowerQuery : IRequest<Int64>
{
    public Int64 Id { get; }

    public CountFollowerQuery(long id)
    {
        Id = id;
    }
}

//public class CountFollowerQuery : IRequest<Int64>
//{
//    public Int64 UserId { get; set; }
//}
//public record Query(Int64 UserId) : IRequest<Int64>;

internal class CountFollowerHandler : IRequestHandler<CountFollowerQuery, Int64>
{
    private readonly AppDbContext _dbContext;

    public CountFollowerHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<long> Handle(CountFollowerQuery request, CancellationToken cancellationToken)
    {
          Int64 count = _dbContext.UserRelations.Where(x => x.UserId == request.Id).Count();
            return Task.FromResult(count);   
    }


        //public Task<Int64> Handle(Query request, CancellationToken cancellationToken)
        //{
        //    Int64 count = _dbContext.UserRelations.Where(x => x.UserId == request.UserId).Count();
        //    return Task.FromResult(count);
        //}


    }

