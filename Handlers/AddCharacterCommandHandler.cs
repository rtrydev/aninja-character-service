using aninja_character_service.Commands;
using aninja_character_service.Models;
using aninja_character_service.Repositories;
using MediatR;

namespace aninja_character_service.Handlers;

public class AddCharacterCommandHandler : IRequestHandler<AddCharacterCommand, Character?>
{
    private ICharacterRepository _characterRepository;

    public AddCharacterCommandHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<Character?> Handle(AddCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = new Character()
        {
            Description = request.Description,
            Gender = request.Gender,
            ImageUrl = request.ImageUrl,
            TranslatedName = request.TranslatedName,
            OriginalName = request.OriginalName,
            VoiceActor = request.VoiceActor,
            VoiceActorImageUrl = request.VoiceActorImageUrl
        };
        var result = await _characterRepository.AddCharacter(character);
        return result;
    }
}