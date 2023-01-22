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
    public class ScoreConfig : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> entity)
        {
            entity.ToTable("Score");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).HasColumnName("id").IsRequired();
            entity.Property(x => x.ScoreDate).HasColumnName("score_date").HasColumnType("datetime").IsRequired();
            entity.Property(x => x.Note).HasColumnName("note").HasColumnType("nvarchar(max)").IsRequired(false);
            entity.Property(x => x.Rescued).HasColumnName("rescue").IsRequired();
            entity.Property(x => x.RescuedDate).HasColumnName("rescued_date").HasColumnType("datetime").IsRequired(false);
            entity.Property(x => x.ClientId).HasColumnName("client_id").IsRequired();
            entity.Property(x => x.UserCreateId).HasColumnName("user_create_id").IsRequired();

            entity.HasOne(x => x.Client).WithMany(x => x.Scores).HasForeignKey(x => x.ClientId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict) ;
            entity.HasOne(x => x.UserCreate).WithMany(x => x.Scores).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.UserCreateId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
