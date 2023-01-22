using Microsoft.EntityFrameworkCore;
using TicketUpService.Domain.Entities;
using TicketUpService.Repository.Configs;

namespace TicketUpService.Repository.Contexts
{
    public class TicketUpContext :DbContext
    {
        public TicketUpContext(DbContextOptions<TicketUpContext> options)
            :base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Score> Scores{ get; set; }
        public DbSet<Store> Stores{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ScoreConfig());
            modelBuilder.ApplyConfiguration(new StoreConfig());
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
        }

    }
}
