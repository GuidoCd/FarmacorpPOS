using Microsoft.EntityFrameworkCore;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ExpressProduct> ExpressProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ExpressSale> ExpressSales { get; set; }
        public DbSet<ErpProduct> ErpProducts { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Fluent API para Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IsActive).IsRequired();
                entity.HasMany(e => e.SubCategories)
                      .WithOne(e => e.ParentCategory)
                      .HasForeignKey(e => e.ParentCategoryId);
            });

            // Configuración de Fluent API para ProductType
            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(100);
            });

            // Configuración de Fluent API para ExpressProduct
            modelBuilder.Entity<ExpressProduct>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.IsActive).IsRequired();
                entity.Property(e => e.ExpirationDate).IsRequired();
                entity.Property(e => e.Remarks).HasMaxLength(250);
                entity.HasOne(e => e.ProductType)
                      .WithMany()
                      .HasForeignKey(e => e.ProductTypeId);
            });

            // Configuración de Fluent API para ProductCategory
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreationDate).IsRequired();
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId);
                entity.HasOne(e => e.Category)
                      .WithMany()
                      .HasForeignKey(e => e.CategoryId);
            });

            // Configuración de Fluent API para ExpressSale
            modelBuilder.Entity<ExpressSale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Customer).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProductName).IsRequired().HasMaxLength(100); // Renombrado de Product a ProductName
                entity.Property(e => e.UniqueProductCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.Discount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Total).IsRequired().HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId);
            });

            // Configuración de Fluent API para ErpProduct
            modelBuilder.Entity<ErpProduct>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cost).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(e => e.UniqueCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RegistrationDate).IsRequired();
                entity.Property(e => e.Stock).IsRequired();
                entity.HasOne(e => e.ExpressProduct)
                      .WithOne()
                      .HasForeignKey<ErpProduct>(e => e.Id);
            });

            // Configuración de Fluent API para Barcode
            modelBuilder.Entity<Barcode>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UniqueCode).IsRequired().HasMaxLength(50);
                entity.Property(e => e.IsActive).IsRequired();
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId);
            });
        }
    }
}
