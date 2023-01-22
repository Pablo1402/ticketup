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
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> entity)
        {
            entity.ToTable("UserProfile");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).IsRequired().HasColumnName("id");
            entity.Property(x => x.Name).IsRequired().HasColumnName("name").HasColumnType("nvarchar(500)");
            entity.HasMany(x => x.Users).WithOne(x => x.UserProfile).HasForeignKey(x => x.UserProfileId).HasPrincipalKey(x => x.Id);
        }
    }
}
