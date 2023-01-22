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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.HasKey(t => t.Id);

            entity.Property(t => t.Id).IsRequired().HasColumnName("id");
            entity.Property(t => t.Name).IsRequired().HasColumnName("name").HasColumnType("nvarchar(500)");
            entity.Property(t => t.Telephone).IsRequired().HasColumnName("telephone").HasColumnType("nvarchar(20)");
            entity.Property(t => t.Login).IsRequired().HasColumnName("login").HasColumnType("nvarchar(200)");
            entity.Property(t => t.Password).IsRequired().HasColumnName("password").HasColumnType("nvarchar(200)");
            entity.Property(t => t.UserProfileId).IsRequired().HasColumnName("user_profile_id");
            entity.Property(t => t.StoreId).IsRequired().HasColumnName("store_id");

            entity.HasOne(x => x.UserProfile).WithMany(x => x.Users).HasForeignKey(x => x.UserProfileId).HasPrincipalKey(x => x.Id);
            entity.HasOne(x => x.Store).WithMany(x => x.Users).HasForeignKey(x => x.StoreId).HasPrincipalKey(x => x.Id);
            entity.HasMany(x => x.Scores).WithOne(x => x.UserCreate).HasForeignKey(x => x.UserCreateId).HasPrincipalKey(x => x.Id);

        }
    }
}
