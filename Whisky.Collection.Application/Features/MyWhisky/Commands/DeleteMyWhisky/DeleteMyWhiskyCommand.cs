using MediatR;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.DeleteMyWhisky;

public class DeleteMyWhiskyCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
