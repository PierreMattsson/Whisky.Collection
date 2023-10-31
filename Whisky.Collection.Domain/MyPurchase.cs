using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Domain;

public class MyPurchase : BaseEntity
{
    public DateTime? PurchaseDate { get; set; }
    public int PurchaseCost { get; set; }
    public MyWhisky? Whisky { get; set; }
    public int WhiskyId { get; set; }
}
