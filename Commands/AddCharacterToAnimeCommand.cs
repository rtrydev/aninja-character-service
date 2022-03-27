using aninja_character_service.Models;
using MediatR;

namespace aninja_character_service.Commands;

public class AddCharacterToAnimeCommand : IRequest<Character?>
{
    public int CharacterId { get; set; }
    public int AnimeId { get; set; }
}