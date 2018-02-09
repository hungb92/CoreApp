using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppContext : DbContext
    {
        public virtual DbSet<CoreAppRoleClaims> CoreAppRoleClaims { get; set; }
        public virtual DbSet<CoreAppRoles> CoreAppRoles { get; set; }
        public virtual DbSet<CoreAppUserClaims> CoreAppUserClaims { get; set; }
        public virtual DbSet<CoreAppUserLogins> CoreAppUserLogins { get; set; }
        public virtual DbSet<CoreAppUserRoles> CoreAppUserRoles { get; set; }
        public virtual DbSet<CoreAppUsers> CoreAppUsers { get; set; }
        public virtual DbSet<CoreAppUserTokens> CoreAppUserTokens { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=I3-PC-NEWMEM;Initial Catalog=CoreAppDbV1;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreAppRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CoreAppRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<CoreAppRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<CoreAppUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CoreAppUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CoreAppUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CoreAppUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CoreAppUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CoreAppUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CoreAppUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CoreAppUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CoreAppUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.LogLevel).HasMaxLength(50);

                entity.Property(e => e.Message).HasMaxLength(4000);
            });
        }
    }
}
