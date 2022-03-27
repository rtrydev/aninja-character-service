using aninja_character_service.Models;
using MediatR;

namespace aninja_character_service.Commands;

public class AddCharacterCommand : IRequest<Character?>
{
    public string OriginalName { get; set; } = "";
    public string TranslatedName { get; set; } = "";
    public string? ImageUrl { get; set; }
    public Gender Gender { get; set; }
    public string VoiceActor { get; set; } = "";
    public string? VoiceActorImageUrl { get; set; }
    public string Description { get; set; } = "";
}