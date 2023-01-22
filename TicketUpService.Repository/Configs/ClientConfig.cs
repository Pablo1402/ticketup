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
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.ToTable("Client");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName("id").IsRequired();
            entity.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(500)").IsRequired();
            entity.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(500)").IsRequired();
            entity.Property(x => x.CreateDate).HasColumnName("create_date").HasColumnType("datetime").IsRequired();
            entity.Property(x => x.StoreId).HasColumnName("store_id").IsRequired();

            entity.HasOne(x => x.Store).WithMany(x => x.Clients).HasForeignKey(x => x.StoreId).HasPrincipalKey(x => x.Id);
            entity.HasMany(x => x.Scores).WithOne(x => x.Client).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.ClientId);

        }
    }
}
