namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetAllMyWhisky;

public class MyWhiskyDTO
{
    // This DTO is to show all Whisky so for this we only incloude the fields we want to see in a view state.
    public int Id { get; set; }
    public string ProducerName { get; set; } = string.Empty;
    public string WhiskyName { get; set; } = string.Empty;
}
