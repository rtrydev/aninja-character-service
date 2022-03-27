using aninja_character_service.Commands;
using aninja_character_service.Models;
using aninja_character_service.Repositories;
using MediatR;

namespace aninja_character_service.Handlers;

public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand, Character?>
{
    private ICharacterRepository _characterRepository;

    public UpdateCharacterCommandHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }
    public async Task<Character?> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.GetCharacterById(request.Id);
        if (character is null) return null;
        character.Description = request.Description;
        character.Gender = request.Gender;
        character.ImageUrl = request.ImageUrl;
        character.TranslatedName = request.TranslatedName;
        character.OriginalName = request.OriginalName;
        character.VoiceActor = request.VoiceActor;
        character.VoiceActorImageUrl = request.VoiceActorImageUrl;

        var result = await _characterRepository.UpdateCharacter(character);
        await _characterRepository.SaveChangesAsync();
        return result;
    }
}