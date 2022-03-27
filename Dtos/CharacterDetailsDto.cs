
using aninja_character_service.Models;

namespace aninja_character_service.Dtos;

public class CharacterDetailsDto
{
    public int Id { get; set; }
    public string OriginalName { get; set; } = "";
    public string TranslatedName { get; set; } = "";
    public string? ImageUrl { get; set; }
    public string Gender { get; set; }
    public string VoiceActor { get; set; } = "";
    public string? VoiceActorImageUrl { get; set; }
    public string Description { get; set; } = "";
}