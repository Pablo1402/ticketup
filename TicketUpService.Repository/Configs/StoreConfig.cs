using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketUpService.Domain.Entities;

namespace TicketUpService.Repository.Configs
{
    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> entity)
        {
            entity.ToTable("Store");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).IsRequired().HasColumnName("id");
            entity.Property(x => x.Name).IsRequired().HasColumnName("name").HasColumnType("nvarchar(500)");
            entity.Property(x => x.CreateDate).IsRequired().HasColumnName("create_date").HasColumnType("datetime");
            entity.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(500)").HasColumnName("email");

            entity.HasMany(x => x.Users).WithOne(x => x.Store).HasForeignKey(x => x.StoreId).HasPrincipalKey(x => x.Id);
            entity.HasMany(x => x.Clients).WithOne(x => x.Store).HasForeignKey(x => x.StoreId).HasPrincipalKey(x => x.Id);

        }
    }
}
