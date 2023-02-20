using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails").HasKey(x =>x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.CrewId).HasColumnName("CrewId");
        builder.Property(x => x.CustomerId).HasColumnName("CustomerId");
        builder.Property(x => x.FoodInfoId).HasColumnName("FoodInfoId");
        builder.Property(x => x.Status).HasColumnName("Status");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasOne(x => x.Crew);
        builder.HasOne(x => x.Customer);
        builder.HasOne(x => x.FoodInfo);
        builder.HasMany(x => x.Payments);
    }
}