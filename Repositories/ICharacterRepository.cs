using aninja_character_service.Models;

namespace aninja_character_service.Repositories;

public interface ICharacterRepository
{
    public Task<IEnumerable<Character>?> GetCharactersForAnime(int animeId);
    public Task<Character?> AddCharacterToAnime(int animeId, int characterId);

    public Task<Character?> GetCharacterById(int characterId);
    public Task<Character?> AddCharacter(Character character);

    public Task<Anime?> AddAnime(Anime anime);
    public Task<Anime?> GetAnimeById(int animeId);
    public Task<bool> AnimeExists(int animeId);
    
}