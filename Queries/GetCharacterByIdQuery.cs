using aninja_character_service.Models;
using MediatR;

namespace aninja_character_service.Queries;

public class GetCharacterByIdQuery : IRequest<Character?>
{
    public int Id { get; set; }
}