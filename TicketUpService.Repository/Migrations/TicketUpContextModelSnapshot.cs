// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketUpService.Repository.Contexts;

#nullable disable

namespace TicketUpService.Repository.Migrations
{
    [DbContext(typeof(TicketUpContext))]
    partial class TicketUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketUpService.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("name");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("store_id");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.Score", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("client_id");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("note");

                    b.Property<bool>("Rescued")
                        .HasColumnType("bit")
                        .HasColumnName("rescue");

                    b.Property<DateTime?>("RescuedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("rescued_date");

                    b.Property<DateTime>("ScoreDate")
                        .HasColumnType("datetime")
                        .HasColumnName("score_date");

                    b.Property<Guid>("UserCreateId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_create_id");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Score", (string)null);
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Store", (string)null);
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("store_id");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telephone");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_profile_id");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.Client", b =>
                {
                    b.HasOne("TicketUpService.Domain.Entities.Store", "Store")
                        .WithMany("Clients")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.Score", b =>
                {
                    b.HasOne("TicketUpService.Domain.Entities.Client", "Client")
                        .WithMany("Scores")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TicketUpService.Domain.Entities.User", "UserCreate")
                        .WithMany("Scores")
                        .HasForeignKey("UserCreateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("UserCreate");
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.User", b =>
                {
                    b.HasOne("TicketUpService.Domain.Entities.Store", "Store")
                        .WithMany("Users")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketUpService.Domain.Entities.UserProfile", "UserProfile")
                        .WithMany("Users")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.Client", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.Store", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.User", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("TicketUpService.Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
