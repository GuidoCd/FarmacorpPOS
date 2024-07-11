using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FarmacorpPOS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmacorpPOS.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // Aquí puedes resolver tus servicios y comenzar la lógica de tu aplicación
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Asegúrate de reemplazar "YourConnectionStringHere" con tu cadena de conexión real
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseSqlServer("YourConnectionStringHere");
                    });

                    // Registrar tus servicios, repositorios, etc.
                });
    }
}
