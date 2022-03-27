using aninja_character_service.Models;
using MediatR;

namespace aninja_character_service.Queries;

public class GetCharactersForAnimeQuery : IRequest<IEnumerable<Character>?>
{
    public int AnimeId { get; set; }
}