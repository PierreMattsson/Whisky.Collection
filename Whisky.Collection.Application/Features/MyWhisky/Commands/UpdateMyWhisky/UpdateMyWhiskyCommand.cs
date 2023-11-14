using MediatR;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.UpdateMyWhisky;

// As IRequest have to return a value, we return "Unit" = same as "void". (Void is not a valid return type)
// So we have to return something but we don't nessesarly expect a return type, we use Unit.
public class UpdateMyWhiskyCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string ProducerName { get; set; } = string.Empty;
    public string WhiskyName { get; set; } = string.Empty;
    public int WhiskyYearStatement { get; set; }
    public string BottleDescription { get; set; } = string.Empty;
    public double AlkoholProcent { get; set; }
    public int BottleContentMilliliter { get; set; }
}
