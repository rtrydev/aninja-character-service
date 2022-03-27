using aninja_character_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aninja_character_service.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("characters")
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OriginalName)
            .HasColumnName("original_name")
            .IsRequired(false);

        builder.Property(x => x.TranslatedName)
            .HasColumnName("translated_name")
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasColumnName("image_url")
            .IsRequired(false);

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .IsRequired(false);

        builder.Property(x => x.Gender)
            .HasColumnName("gender")
            .IsRequired();

        builder.Property(x => x.VoiceActor)
            .HasColumnName("voice_actor")
            .IsRequired(false);

        builder.Property(x => x.VoiceActorImageUrl)
            .HasColumnName("voice_actor_image_url")
            .IsRequired(false);
    }
}