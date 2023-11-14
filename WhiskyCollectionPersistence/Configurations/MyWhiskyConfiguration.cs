using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whisky.Collection.Domain;

namespace WhiskyCollectionPersistence.Configurations;

public class MyWhiskyConfiguration : IEntityTypeConfiguration<MyWhisky>
{
    public void Configure(EntityTypeBuilder<MyWhisky> builder)
    {
        builder.HasData(
            new MyWhisky
            {
                Id = 1,
                ProducerName = "Macallan",
                WhiskyName = "Double Cask",
                WhiskyYearStatement = 12,
                BottleDescription = "Highland Single Malt Scotch Whisky",
                AlkoholProcent = 40,
                BottleContentMilliliter = 700,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
        );
    }
}
