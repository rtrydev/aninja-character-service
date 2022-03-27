using aninja_character_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aninja_character_service.Configurations;

public class AnimeCharacterConfiguration : IEntityTypeConfiguration<AnimeCharacter>
{
    public void Configure(EntityTypeBuilder<AnimeCharacter> builder)
    {
        builder.ToTable("anime_character");

        builder.HasKey(x => new {x.AnimeId, x.CharacterId});
        
        builder.HasOne(x => x.Anime)
            .WithMany(x => x.Characters)
            .HasForeignKey(x => x.AnimeId);

        builder.Property(x => x.AnimeId)
            .HasColumnName("anime_id");

        builder.HasOne(x => x.Character)
            .WithMany(x => x.Animes)
            .HasForeignKey(x => x.CharacterId);

        builder.Property(x => x.CharacterId)
            .HasColumnName("character_id");
    }
}