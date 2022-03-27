using aninja_character_service.Models;
using aninja_character_service.Queries;
using aninja_character_service.Repositories;
using MediatR;

namespace aninja_character_service.Handlers;

public class GetCharactersForAnimeQueryHandler : IRequestHandler<GetCharactersForAnimeQuery, IEnumerable<Character>?>
{
    private ICharacterRepository _characterRepository;

    public GetCharactersForAnimeQueryHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<IEnumerable<Character>?> Handle(GetCharactersForAnimeQuery request, CancellationToken cancellationToken)
    {
        var anime = await _characterRepository.GetAnimeById(request.AnimeId);
        if (anime is null) return null;
        if (anime.Characters is null) return Array.Empty<Character>();
        var characterIds = anime.Characters.Select(x => x.CharacterId);
        var characters = new List<Character>();
        foreach (var id in characterIds)
        {
            var character = await _characterRepository.GetCharacterById(id);
            if (character is not null) characters.Add(character);
        }

        return characters;
    }
}