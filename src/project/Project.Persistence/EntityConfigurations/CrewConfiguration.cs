using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Persistence.EntityConfigurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crews").HasKey(x=>x.Id);
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
        }
    }
}
