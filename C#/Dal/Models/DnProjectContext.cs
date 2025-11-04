using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal_Repository.Models;

public partial class DnProjectContext : DbContext
{
    public DnProjectContext()
    {
    }

    public DnProjectContext(DbContextOptions<DnProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInCart> ProductInCarts { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server= .;Database=dn_project;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1D824D07DAC");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__AD54599045BDC961");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId)
                .ValueGeneratedNever()
                .HasColumnName("companyId");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("companyName");
        }); 

       modelBuilder.Entity<Customer>(entity =>
{
    entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB7D9213FAC1");

    entity.ToTable("Customer");

    entity.Property(e => e.CustomerId)
        .ValueGeneratedNever()
        .HasColumnName("customerId");
    entity.Property(e => e.Birthday)
        .HasColumnType("date")
        .HasColumnName("birthday");
    entity.Property(e => e.CustomerName)
        .HasMaxLength(255)
        .IsUnicode(false)
        .HasColumnName("customerName");
    entity.Property(e => e.Email)
        .HasMaxLength(255)
        .IsUnicode(false)
        .HasColumnName("email");
    entity.Property(e => e.Phone) // עדכון הטיפוס ל- string
        .HasMaxLength(20) // קבע את האורך המקסימלי הרצוי
        .IsUnicode(false)
        .HasColumnName("phone");
});

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D16A5DE8D856");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("productId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdatedDate");
            entity.Property(e => e.MatchAge).HasColumnName("matchAge");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("productName");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__categor__3D5E1FD2");

            entity.HasOne(d => d.Company).WithMany(p => p.Products)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__company__3E52440B");
        });

        modelBuilder.Entity<ProductInCart>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.Quantity }).HasName("PK__ProductI__4004ADC15767A9AE");

            entity.ToTable("ProductInCart");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CompanyId).HasColumnName("companyId");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdatedDate");
            entity.Property(e => e.MatchAge).HasColumnName("matchAge");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductInCarts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIn__categ__412EB0B6");

            entity.HasOne(d => d.Company).WithMany(p => p.ProductInCarts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIn__compa__4222D4EF");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__0261226C78421BEC");

            entity.ToTable("Purchase");

            entity.Property(e => e.PurchaseId)
                .ValueGeneratedNever()
                .HasColumnName("purchaseId");
            entity.Property(e => e.AmountPay)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amountPay");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchaseDate");
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("remark");

            entity.HasOne(d => d.Customer).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purchase__custom__44FF419A");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.PurchaseDetailsId).HasName("PK__Purchase__67AF052962F3D084");

            entity.Property(e => e.PurchaseDetailsId)
                .ValueGeneratedNever()
                .HasColumnName("purchaseDetailsId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__produ__48CFD27E");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__purch__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
