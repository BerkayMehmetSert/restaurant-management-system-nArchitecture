using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus").HasKey(x =>x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.FoodInfoId).HasColumnName("FoodInfoId");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

        builder.HasOne(x => x.FoodInfo);
    }
}