namespace aninja_character_service.Models;

public class AnimeCharacter
{
    public int AnimeId { get; set; }
    public Anime? Anime { get; set; }
    public int CharacterId { get; set; }
    public Character? Character { get; set; }
}