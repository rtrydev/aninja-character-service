using aninja_character_service.Commands;
using aninja_character_service.Dtos;
using aninja_character_service.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace aninja_character_service.Controllers;

[ApiController]
[Route("api/c")]
public class AnimeCharacterController : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;

    public AnimeCharacterController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("anime/{animeId}/character")]
    public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharactersForAnime(int animeId)
    {
        var request = new GetCharactersForAnimeQuery() {AnimeId = animeId};
        var result = await _mediator.Send(request);
        if (result is null) return NotFound();
        return Ok(_mapper.Map<IEnumerable<CharacterDto>>(result));
    }

    [HttpPut("anime/{animeId}/character/{characterId}")]
    public async Task<ActionResult<CharacterDto>> AddCharacterToAnime(int animeId, int characterId)
    {
        var request = new AddCharacterToAnimeCommand()
        {
            AnimeId = animeId,
            CharacterId = characterId
        };
        var result = await _mediator.Send(request);
        if (result is null) return NotFound();
        return Ok(_mapper.Map<CharacterDto>(result));
    }
}