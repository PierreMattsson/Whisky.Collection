using MediatR;

namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyDetails;

// Record apply an expected parameter (inforced rules), diffrent from class that can have options 
public record GetMyWhiskyDetailsQuery(int Id) : IRequest<MyWhiskyDetailsDTO>;
