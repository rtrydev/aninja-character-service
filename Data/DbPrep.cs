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
        }
    }
}