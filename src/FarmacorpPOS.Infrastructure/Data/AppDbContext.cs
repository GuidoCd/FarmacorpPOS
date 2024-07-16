using Microsoft.EntityFrameworkCore;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
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
            base.OnModelCreating(modelBuilder);
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
                entity.Property(e => e.Observations).HasMaxLength(250);
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

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Description = "Category 1", IsActive = true },
                new Category { Id = 2, Description = "Category 2", IsActive = true },
                new Category { Id = 3, Description = "Category 3", IsActive = true },
                new Category { Id = 4, Description = "Category 4", IsActive = true },
                new Category { Id = 5, Description = "Category 5", IsActive = true },
                new Category { Id = 6, Description = "Category 6", IsActive = true },
                new Category { Id = 7, Description = "Category 7", IsActive = true },
                new Category { Id = 8, Description = "Category 8", IsActive = true },
                new Category { Id = 9, Description = "Category 9", IsActive = true },
                new Category { Id = 10, Description = "Category 10", IsActive = true }
            );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Description = "ProductType 1" },
                new ProductType { Id = 2, Description = "ProductType 2" },
                new ProductType { Id = 3, Description = "ProductType 3" },
                new ProductType { Id = 4, Description = "ProductType 4" },
                new ProductType { Id = 5, Description = "ProductType 5" },
                new ProductType { Id = 6, Description = "ProductType 6" },
                new ProductType { Id = 7, Description = "ProductType 7" },
                new ProductType { Id = 8, Description = "ProductType 8" },
                new ProductType { Id = 9, Description = "ProductType 9" },
                new ProductType { Id = 10, Description = "ProductType 10" }
            );
        }
    }
}
