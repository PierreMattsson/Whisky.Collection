namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyDetails;

public class MyWhiskyDetailsDTO
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string ProducerName { get; set; } = string.Empty;
    public string WhiskyName { get; set; } = string.Empty;
    public int WhiskyYearStatement { get; set; }
    public string BottleDescription { get; set; } = string.Empty;
    public double AlkoholProcent { get; set; }
    public int BottleContentMilliliter { get; set; }
}
