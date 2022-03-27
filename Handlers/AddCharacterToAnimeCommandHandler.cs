using aninja_character_service.Commands;
using aninja_character_service.Models;
using aninja_character_service.Repositories;
using MediatR;

namespace aninja_character_service.Handlers;

public class AddCharacterToAnimeCommandHandler : IRequestHandler<AddCharacterToAnimeCommand, Character?>
{
    private ICharacterRepository _characterRepository;

    public AddCharacterToAnimeCommandHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<Character?> Handle(AddCharacterToAnimeCommand request, CancellationToken cancellationToken)
    {
        var anime = await _characterRepository.GetAnimeById(request.AnimeId);
        if (anime is null) return null;
        var character = await _characterRepository.GetCharacterById(request.CharacterId);
        if (character is null) return null;
        if (anime.Characters is null)
        {
            anime.Characters = new List<AnimeCharacter>() {new AnimeCharacter() {AnimeId = anime.Id, CharacterId = character.Id}};
        }
        else
        {
            anime.Characters.Add(new AnimeCharacter() {AnimeId = anime.Id, CharacterId = character.Id});
        }

        await _characterRepository.UpdateAnime(anime);
        await _characterRepository.SaveChangesAsync();

        return character;
    }
}