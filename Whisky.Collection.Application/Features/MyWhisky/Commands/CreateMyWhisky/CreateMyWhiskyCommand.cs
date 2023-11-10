using MediatR;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.CreateMyWhisky;

public class CreateMyWhiskyCommand : IRequest<int>
{
    public string ProducerName { get; set; } = string.Empty;
    public string WhiskyName { get; set; } = string.Empty;
    public int WhiskyYearStatement { get; set; }
    public string BottleDescription { get; set; } = string.Empty;
    public double AlkoholProcent { get; set; }
    public int BottleContentMilliliter { get; set; }
}
