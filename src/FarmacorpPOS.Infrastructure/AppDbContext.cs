using Microsoft.EntityFrameworkCore;
using FarmacorpPOS.Domain.Entities;


namespace FarmacorpPOS.Infrastructure
{
  public class AppDbContext: DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}

    public DbSet<Product> Products { get; set; }
    public DbSet<Barcode> Barcodes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Sale> Sales { get; set; }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

  }
  
}