using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerce_API.Models
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<LoginDetail> LoginDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Ecommerce;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("PK__Admin__DE508E2E7B39B3B9");

                entity.ToTable("Admin");

                entity.Property(e => e.Aid).HasColumnName("aid");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PK__Brands__C6D111C9F8CCC286");

                entity.Property(e => e.Bid).ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginDetail>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__LoginDet__D837D05F3A080C01");

                entity.HasIndex(e => e.Email, "UQ__LoginDet__AB6E616498ED315D")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__LoginDet__F3DBC57256CBAB30")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNo, "UQ__LoginDet__F3EE33E23E4D122F")
                    .IsUnique();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pwd");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.OrderId, "UQ__orders__0809335C9C185253")
                    .IsUnique();

                entity.HasIndex(e => e.Invoice, "UQ__orders__6ED2F88A2FB4081F")
                    .IsUnique();

                entity.HasIndex(e => e.Invoice, "UQ__orders__6ED2F88A634FB3A9")
                    .IsUnique();

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("orderId");

                entity.Property(e => e.DateOfOrder).HasColumnType("date");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("invoice");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__orders__CustId__5535A963");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("orderDetails");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__orderDeta__Order__6477ECF3");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__orderDetail__Pid__656C112C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Product__C5705938BCEBE717");

                entity.ToTable("Product");

                entity.Property(e => e.Pid).ValueGeneratedNever();

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Imglink)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("imglink");

                entity.Property(e => e.ScType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandId__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
