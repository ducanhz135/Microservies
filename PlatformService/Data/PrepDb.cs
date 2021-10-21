using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("---> Attempting to aplly migration...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"---> Could not run migration {ex.Message}"); ;
                }
                
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> seeding data...");
                context.Platforms.AddRange(
                    new Platform() { Name="Dot Net", Publisher="Microsoft", Cost="free"},
                    new Platform() { Name = "SQL server express", Publisher = "Microsoft", Cost = "free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud native computing foundaton", Cost = "free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> we already have data");
            }
        }
    }
}
