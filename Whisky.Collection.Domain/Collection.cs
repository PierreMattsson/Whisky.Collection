using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Domain;

public class Collection : BaseEntity
{
    public string TasteDescription { get; set; } = string.Empty;
    public Whisky? Whisky { get; set; }
}
