using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMS.Entities
{
    public partial class IMSDBContext : DbContext
    {
        public IMSDBContext(DbContextOptions<IMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MasterBarang> MasterBarangs { get; set; } = null!;
        public virtual DbSet<MasterGudang> MasterGudangs { get; set; } = null!;
        public virtual DbSet<MasterUser> MasterUsers { get; set; } = null!;
        public virtual DbSet<Outlet> Outlets { get; set; } = null!;
        public virtual DbSet<StockTransaction> StockTransactions { get; set; } = null!;
        public virtual DbSet<UserRoleEnum> UserRoleEnums { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Inventory_Management_System;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterBarang>(entity =>
            {
                entity.HasKey(e => e.SKUID);

                entity.ToTable("MasterBarang");

                entity.Property(e => e.SKUID)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");
            });

            modelBuilder.Entity<MasterGudang>(entity =>
            {
                entity.HasKey(e => e.GudangCode)
                    .HasName("PK_GudangCode");

                entity.ToTable("MasterGudang");

                entity.Property(e => e.GudangCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OutletCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.OutletCodeNavigation)
                    .WithMany(p => p.MasterGudangs)
                    .HasForeignKey(d => d.OutletCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MasterGudang_Outlet");
            });

            modelBuilder.Entity<MasterUser>(entity =>
            {
                entity.HasKey(e => e.UserCode)
                    .HasName("PK_User");

                entity.ToTable("MasterUser");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.UserRoleEnum)
                    .WithMany(p => p.MasterUsers)
                    .HasForeignKey(d => d.UserRoleEnumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRoleEnum");
            });

            modelBuilder.Entity<Outlet>(entity =>
            {
                entity.HasKey(e => e.OutletCode);

                entity.ToTable("Outlet");

                entity.Property(e => e.OutletCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");
            });

            modelBuilder.Entity<StockTransaction>(entity =>
            {
                entity.ToTable("StockTransaction");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.SKUID)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.HasOne(d => d.SKU)
                    .WithMany(p => p.StockTransactions)
                    .HasForeignKey(d => d.SKUID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdjustmentStock_MasterBarang");
            });

            modelBuilder.Entity<UserRoleEnum>(entity =>
            {
                entity.ToTable("UserRoleEnum");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
