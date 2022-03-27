using aninja_character_service.Configurations;
using aninja_character_service.Models;
using Microsoft.EntityFrameworkCore;

namespace aninja_character_service.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Anime> Animes { get; set; }
    public virtual DbSet<Character> Characters { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AnimeConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new AnimeCharacterConfiguration());
    }
}