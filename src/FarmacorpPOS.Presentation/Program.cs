using System;
using FarmacorpPOS.Infrastructure.Services;
using FarmacorpPOS.Infrastructure.Data;
using FarmacorpPOS.Infrastructure.Repositories;
using FarmacorpPOS.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FarmacorpPOS.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options => 
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")
                    ))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ERPProductService>()
                .AddScoped<SaleService>()
                .BuildServiceProvider();

            var productService = serviceProvider.GetService<ERPProductService>();
            var saleService = serviceProvider.GetService<SaleService>();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Register new product");
                Console.WriteLine("2. Register sale");
                Console.WriteLine("3. Exit");

                var option = Console.ReadLine();

                if (option == "1")
                {
                    RegisterNewProduct(productService);
                }
                else if (option == "2")
                {
                    RegisterSale(saleService);
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }
        }

        private static void RegisterNewProduct(ERPProductService productService)
        {
            Console.WriteLine("Enter product name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter product cost:");
            var cost = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter product stock:");
            var stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product type ID:");
            var productTypeId = int.Parse(Console.ReadLine());

            productService.RegisterNewProduct(name, cost, stock, productTypeId);
            Console.WriteLine("Product registered successfully.");
        }

        private static void RegisterSale(SaleService saleService)
        {
            Console.WriteLine("Enter product ID:");
            var productId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter quantity:");
            var quantity = int.Parse(Console.ReadLine());

            try
            {
                saleService.RegisterSale(productId, quantity);
                Console.WriteLine("Sale registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
