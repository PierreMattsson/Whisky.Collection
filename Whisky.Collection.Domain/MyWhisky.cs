using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Domain;

public class MyWhisky : BaseEntity
{
    public string ProducerName { get; set; } = string.Empty;
    public string WhiskyName { get; set; } = string.Empty;
    public int WhiskyYearStatement { get; set; }
    public string BottleDescription { get; set; } = string.Empty;
    public double AlkoholProcent { get; set; }
    public int BottleContentMilliliter { get; set; }
}
