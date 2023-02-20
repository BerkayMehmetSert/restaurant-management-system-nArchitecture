using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.Contact).HasColumnName("Contact");
        builder.Property(x => x.Address).HasColumnName("Address");
        builder.Property(x => x.Username).HasColumnName("Username");
        builder.Property(x => x.Password).HasColumnName("Password");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasMany(x => x.TransactionReports);
        builder.HasMany(x => x.OrderDetails);
        builder.HasMany(x => x.Payments);
    }
}