using aninja_character_service.Data;
using aninja_character_service.Models;
using Microsoft.EntityFrameworkCore;

namespace aninja_character_service.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private AppDbContext _dbContext;

    public CharacterRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Character?> GetCharacterById(int characterId)
    {
        var character = await _dbContext.Characters.FirstOrDefaultAsync(x => x.Id == characterId);
        return character;
    }

    public async Task<Character?> AddCharacter(Character character)
    {
        var result = await _dbContext.Characters.AddAsync(character);
        return result.Entity;
    }

    public async Task<Character?> UpdateCharacter(Character character)
    {
        var dbChar = await GetCharacterById(character.Id);
        if (dbChar is null) return null;
        dbChar.Description = character.Description;
        dbChar.Gender = character.Gender;
        dbChar.ImageUrl = character.ImageUrl;
        dbChar.OriginalName = character.OriginalName;
        dbChar.TranslatedName = character.TranslatedName;
        dbChar.VoiceActor = character.VoiceActor;
        dbChar.VoiceActorImageUrl = character.VoiceActorImageUrl;
        return _dbContext.Characters.Update(dbChar).Entity;
    }

    public async Task<Anime?> AddAnime(Anime anime)
    {
        if (await AnimeExists(anime.ExternalId)) return null;
        var result = await _dbContext.Animes.AddAsync(anime);
        return result.Entity;
    }

    public async Task<Anime?> GetAnimeById(int animeId)
    {
        var anime = await _dbContext.Animes.FirstOrDefaultAsync(x => x.ExternalId == animeId);
        return anime;
    }

    public async Task<Anime?> UpdateAnime(Anime anime)
    {
        var dbItem = await _dbContext.Animes.FirstOrDefaultAsync(x => x.ExternalId == anime.ExternalId);
        if(dbItem is null) return null;
        if(dbItem.TranslatedTitle == anime.TranslatedTitle) return null;
        dbItem.TranslatedTitle = anime.TranslatedTitle;
        return _dbContext.Animes.Update(dbItem).Entity;
    }

    public async Task<bool> AnimeExists(int animeId)
    {
        return await _dbContext.Animes.AnyAsync(x => x.ExternalId == animeId);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync() > 0;
    }
}