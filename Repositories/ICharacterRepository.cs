using aninja_character_service.Models;

namespace aninja_character_service.Repositories;

public interface ICharacterRepository
{
    public Task<Character?> GetCharacterById(int characterId);
    public Task<Character?> AddCharacter(Character character);
    public Task<Character?> UpdateCharacter(Character character);

    public Task<Anime?> AddAnime(Anime anime);
    public Task<Anime?> GetAnimeById(int animeId);
    public Task<Anime?> UpdateAnime(Anime anime);
    public Task<bool> AnimeExists(int animeId);

    public Task<bool> SaveChangesAsync();

}