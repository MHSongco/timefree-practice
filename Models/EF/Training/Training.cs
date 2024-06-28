using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace timefree_training_api.Models.EF.Training
{
    public partial class Training : DbContext
    {
        public Training()
        {
        }

        public Training(DbContextOptions<Training> options)
            : base(options)
        {
        }

        public virtual DbSet<order> order { get; set; } = null!;
        public virtual DbSet<product> product { get; set; } = null!;
        public virtual DbSet<user> user { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=test;User ID=SA;Password=MyStrongPass123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_100_CI_AS");

            modelBuilder.Entity<order>(entity =>
            {
                entity.HasKey(e => e.guid)
                    .HasName("PK__order__497F6CB4B1D89AD3");

                entity.ToTable("order", "timefree_training");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e._deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.created_by_ip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.date_created).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.modified_by_ip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.product_gu)
                    .WithMany(p => p.order)
                    .HasForeignKey(d => d.product_guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_product");

                entity.HasOne(d => d.user_gu)
                    .WithMany(p => p.order)
                    .HasForeignKey(d => d.user_guid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_user");
            });

            modelBuilder.Entity<product>(entity =>
            {
                entity.HasKey(e => e.guid)
                    .HasName("PK__product__497F6CB4C4C2D7CA");

                entity.ToTable("product", "timefree_training");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.created_by_ip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.date_created).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.modified_by_ip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.name).HasMaxLength(400);

                entity.Property(e => e.price).HasColumnType("money");
            });

            modelBuilder.Entity<user>(entity =>
            {
                entity.HasKey(e => e.guid)
                    .HasName("PK__user__497F6CB49537C6C3");

                entity.ToTable("user", "timefree_training");

                entity.Property(e => e.guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.created_by_ip)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.date_created)
                    .HasDefaultValueSql("(getutcdate())")
                    .HasComment("always in UTC time");

                entity.Property(e => e.first_name).HasMaxLength(100);

                entity.Property(e => e.last_name).HasMaxLength(100);

                entity.Property(e => e.modified_by_ip)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
