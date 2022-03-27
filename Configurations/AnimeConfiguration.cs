using aninja_character_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aninja_character_service.Configurations;

public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
{
    public void Configure(EntityTypeBuilder<Anime> builder)
    {
        builder.ToTable("animes")
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnType("int")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ExternalId)
            .HasColumnName("external_id")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.TranslatedTitle)
            .HasColumnName("translated_title")
            .HasColumnType("string")
            .IsRequired(false);
        
        
    }
}