using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Domain;

public class Purchase : BaseEntity
{
    public DateTime? PurchaseDate { get; set; }
    public int PurchaseCost { get; set; }
    public Whisky? Whisky { get; set; }
}
