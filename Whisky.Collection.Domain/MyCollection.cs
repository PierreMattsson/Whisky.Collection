using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Domain;

public class MyCollection : BaseEntity
{
    public string TasteDescription { get; set; } = string.Empty;
    public MyWhisky? Whisky { get; set; }
    public int WhiskyId { get; set; }
}
