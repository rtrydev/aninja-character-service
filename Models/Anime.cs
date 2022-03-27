namespace aninja_character_service.Models;

public class Anime
{
    public int Id { get; set; }
    public int ExternalId { get; set; }
    public string? TranslatedTitle { get; set; }
    public ICollection<AnimeCharacter>? Characters { get; set; }
}