using aninja_character_service.Models;
using aninja_character_service.Queries;
using aninja_character_service.Repositories;
using MediatR;

namespace aninja_character_service.Handlers;

public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Character?>
{
    private ICharacterRepository _characterRepository;

    public GetCharacterByIdQueryHandler(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<Character?> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
    {
        var character = await _characterRepository.GetCharacterById(request.Id);
        return character;
    }
}