using aninja_character_service.Models;

namespace aninja_character_service.SyncDataServices;

public interface IAnimeDataClient
{
    IEnumerable<Anime> ReturnAllAnime();
}