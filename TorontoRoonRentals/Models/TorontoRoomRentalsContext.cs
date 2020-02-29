using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TorontoRoonRentals.ViewModels;

namespace TorontoRoonRentals.Models
{
    public partial class TorontoRoomRentalsContext : DbContext
    {
        public TorontoRoomRentalsContext()
        {
        }

        public TorontoRoomRentalsContext(DbContextOptions<TorontoRoomRentalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appliances> Appliances { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Description> Description { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomImages> RoomImages { get; set; }
        public virtual DbSet<Utilities> Utilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:roomrentals.database.windows.net,1433;Initial Catalog=TorontoRoomRentals;Persist Security Info=False;User ID=dudgnl23;Password=mk232312@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appliances>(entity =>
            {
                entity.HasKey(e => e.ApplianceId);

                entity.Property(e => e.ApplianceId).HasColumnName("Appliance_ID");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Appliances)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appliance__Room___07C12930");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.Property(e => e.DescriptionId).HasColumnName("Description_ID");

                entity.Property(e => e.Availability)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MainDescription)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Neighborhood)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.Space)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Transportation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Description)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Descripti__Room___04E4BC85");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.ProfileId)
                    .HasColumnName("profileId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Introduction)
                    .HasColumnName("introduction")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Languages)
                    .HasColumnName("languages")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProfileNavigation)
                    .WithOne(p => p.Profile)
                    .HasForeignKey<Profile>(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profile__profile__10566F31");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("reviewId");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .IsUnicode(false);

                entity.Property(e => e.ProfileId)
                    .IsRequired()
                    .HasColumnName("profileId")
                    .HasMaxLength(450);

                entity.Property(e => e.Reviewdate)
                    .HasColumnName("reviewdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__profileI__160F4887");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.Moveindate)
                    .HasColumnName("moveindate")
                    .HasColumnType("date");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__userId__7B5B524B");
            });

            modelBuilder.Entity<RoomImages>(entity =>
            {
                entity.HasKey(e => e.RoomImageId);

                entity.Property(e => e.RoomImageId).HasColumnName("roomImageId");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnName("imagePath")
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomImages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomImage__roomI__7F2BE32F");
            });

            modelBuilder.Entity<Utilities>(entity =>
            {
                entity.HasKey(e => e.UtilityId);

                entity.Property(e => e.UtilityId).HasColumnName("Utility_ID");

                entity.Property(e => e.HasTv).HasColumnName("HasTV");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                //entity.HasOne(d => d.Room)
                //    .WithMany(p => p.Utilities)
                //    .HasForeignKey(d => d.RoomId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__Utilities__Room___02084FDA");
            });
        }

        public DbSet<TorontoRoonRentals.ViewModels.LocationVM> LocationVM { get; set; }
    }
}
