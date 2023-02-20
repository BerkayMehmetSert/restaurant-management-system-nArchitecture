using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments").HasKey(x =>x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.CustomerId).HasColumnName("CustomerId");
        builder.Property(x => x.OrderDetailId).HasColumnName("OrderDetailId");
        builder.Property(x => x.DeliveryId).HasColumnName("DeliveryId");
        builder.Property(x => x.Amount).HasColumnName("Amount");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasOne(x => x.Customer);
        builder.HasOne(x => x.OrderDetail);
        builder.HasOne(x => x.Delivery);
    }
}