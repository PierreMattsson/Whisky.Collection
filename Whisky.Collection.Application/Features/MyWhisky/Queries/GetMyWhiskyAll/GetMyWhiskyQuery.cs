using MediatR;

namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyAll;
// This will handle the request message and send the DTO to the API
// Useing Record "inmuteable" meaning once it defined nothing will change it
public record GetMyWhiskyQuery : IRequest<List<MyWhiskyDTO>>;
