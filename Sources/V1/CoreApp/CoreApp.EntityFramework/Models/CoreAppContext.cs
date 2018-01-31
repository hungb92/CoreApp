using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApp.EntityFramework.Models
{
    public partial class CoreAppContext : DbContext
    {
        public virtual DbSet<CoreAppLoginProviders> CoreAppLoginProviders { get; set; }
        public virtual DbSet<CoreAppRoles> CoreAppRoles { get; set; }
        public virtual DbSet<CoreAppUserRoles> CoreAppUserRoles { get; set; }
        public virtual DbSet<CoreAppUsers> CoreAppUsers { get; set; }
        public virtual DbSet<CoreAppUserTokens> CoreAppUserTokens { get; set; }

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
            modelBuilder.Entity<CoreAppLoginProviders>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<CoreAppRoles>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CoreAppUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CoreAppUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_CoreAppUserRoles_CoreAppRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CoreAppUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CoreAppUserRoles_CoreAppUsers");
            });

            modelBuilder.Entity<CoreAppUsers>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PasswordHash).IsUnicode(false);

                entity.Property(e => e.SecurityStamp).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CoreAppUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProviderId, e.Name });

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.HasOne(d => d.LoginProvider)
                    .WithMany(p => p.CoreAppUserTokens)
                    .HasForeignKey(d => d.LoginProviderId)
                    .HasConstraintName("FK_CoreAppUserTokens_CoreAppLoginProviders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CoreAppUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CoreAppUserTokens_CoreAppUsers");
            });
        }
    }
}
