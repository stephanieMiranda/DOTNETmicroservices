/*
This will be used for migrations later down the line.
More for testing, not production.
*/

using System;
using System.Linq;
using System.Security;
using System.Security.Policy;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data 
{
     public static class PrepDb
     {
          //don't need to instantiate a static class

          public static void PrepPopulation(IApplicationBuilder app)
          {
               using( var serviceScope = app.ApplicationServices.CreateScope())
               {
                    SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
               }
          }

          private static void SeedData(AppDbContext context)
          {
               if(!context.Platforms.Any())
               {
                    //push data
                    Console.WriteLine("---> Seeding data...");

                    //directly adding objects
                    context.Platforms.AddRange(
                         new Models.Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                         new Models.Platform() {Name="SQL Server Express", Publisher="Microsoft", Cost="Free"},
                         new Models.Platform() {Name="Kubernetes", Publisher="Cloud Natice Computing Foundation", Cost="Free"}
                    );
                    context.SaveChanges();
               }else{
                    Console.WriteLine("---> We already have data");
               }
          }
     }
}