namespace aninja_character_service.Models;

public enum Gender
{
    Male,
    Female,
    Undefined
}

public class Character
{
    public int Id { get; set; }
    public string OriginalName { get; set; } = "";
    public string TranslatedName { get; set; } = "";
    public string? ImageUrl { get; set; }
    public Gender Gender { get; set; }
    public string VoiceActor { get; set; } = "";
    public string? VoiceActorImageUrl { get; set; }
    public string Description { get; set; } = "";
    public IEnumerable<AnimeCharacter>? Animes { get; set; }
}