using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations;

public class FoodInfoConfiguration : IEntityTypeConfiguration<FoodInfo>
{
    public void Configure(EntityTypeBuilder<FoodInfo> builder)
    {
        builder.ToTable("FoodInfos").HasKey(x =>x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.Status).HasColumnName("Status");
        builder.Property(x => x.Price).HasColumnName("Price");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasMany(x => x.Menus);
        builder.HasMany(x => x.OrderDetails);
    }
}