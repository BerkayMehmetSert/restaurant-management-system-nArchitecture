using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations;

public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("Deliveries").HasKey(x =>x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.OrderDetailId).HasColumnName("OrderDetailId");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasOne(x => x.OrderDetail);
        builder.HasMany(x => x.Payments);
    }
}