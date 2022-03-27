using aninja_character_service.Models;
using aninja_character_service.Repositories;
using aninja_character_service.SyncDataServices;
using Microsoft.EntityFrameworkCore;

namespace aninja_character_service.Data;

public class DbPrep
{
    public static async Task PrepData(IApplicationBuilder app, bool isProduction)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            if (context is not null)
            {
                await context.Database.MigrateAsync();
            }
            if (isProduction)
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IAnimeDataClient>();
                if (grpcClient is not null)
                {
                    var anime = grpcClient.ReturnAllAnime(); 
                    await SeedData(serviceScope.ServiceProvider.GetService<ICharacterRepository>()!, anime); 
                }
            }
        }
    }
    private static async Task SeedData(ICharacterRepository ratingRepository, IEnumerable<Anime> anime)
    {
        foreach (var a in anime)
        {
            if (!await ratingRepository.AnimeExists(a.ExternalId))
            {
                await ratingRepository.AddAnime(a);
            }
        }
        await ratingRepository.SaveChangesAsync();
    }
}