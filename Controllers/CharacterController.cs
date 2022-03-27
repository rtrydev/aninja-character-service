using aninja_character_service.Commands;
using aninja_character_service.Dtos;
using aninja_character_service.Models;
using aninja_character_service.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace aninja_character_service.Controllers;

[ApiController]
[Route("api/c")]
public class CharacterController : ControllerBase
{
    private IMediator _mediator;
    private IMapper _mapper;

    public CharacterController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("character/{id}")]
    public async Task<ActionResult<CharacterDetailsDto>> GetCharacterById(int id)
    {
        var request = new GetCharacterByIdQuery() {Id = id};
        var result = await _mediator.Send(request);
        if (result is null) return NotFound();
        return Ok(_mapper.Map<CharacterDetailsDto>(result));
    }

    [HttpPost("character")]
    public async Task<ActionResult<CharacterDetailsDto>> AddCharacter(CharacterWriteDto character)
    {
        var request = new AddCharacterCommand()
        {
            Description = character.Description,
            Gender = Enum.Parse<Gender>(character.Gender),
            ImageUrl = character.ImageUrl,
            OriginalName = character.OriginalName,
            TranslatedName = character.TranslatedName,
            VoiceActor = character.VoiceActor,
            VoiceActorImageUrl = character.VoiceActorImageUrl
        };
        var result = await _mediator.Send(request);
        return Ok(_mapper.Map<CharacterDetailsDto>(result));
    }

    [HttpPut("character")]
    public async Task<ActionResult<CharacterDetailsDto>> UpdateCharacter(CharacterUpdateDto character)
    {
        var request = new UpdateCharacterCommand()
        {
            Id = character.Id,
            Description = character.Description,
            Gender = Enum.Parse<Gender>(character.Gender),
            ImageUrl = character.ImageUrl,
            OriginalName = character.OriginalName,
            TranslatedName = character.TranslatedName,
            VoiceActor = character.VoiceActor,
            VoiceActorImageUrl = character.VoiceActorImageUrl
        };
        var result = await _mediator.Send(request);
        if (result is null) return NotFound();
        return Ok(_mapper.Map<CharacterDetailsDto>(result));
    }
    
}