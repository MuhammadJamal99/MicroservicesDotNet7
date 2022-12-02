using Microsoft.IdentityModel.Tokens;
using PlatformService.Models;

namespace PlatformService.Data.DataSeeds;

public static class DataSeeder
{
    public static void SeedsDataPopulation(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope()) 
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        };
    }
    private static void SeedData(AppDbContext context) 
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine(" --> Seeding Data...");
            context.AddRange(
                new Platform() { Name ="Dot Net", Publisher ="Microsoft", Cost = "Free"},
                new Platform() { Name ="Sql Server Express", Publisher="Microsoft", Cost = "Free"},
                new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
            );
            context.SaveChanges();
        }
        else
            Console.WriteLine(" --> We Already Hava Data");
    }   
}
