using aninja_character_service.Dtos;
using aninja_character_service.Models;
using AutoMapper;

namespace aninja_character_service.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Character, CharacterDetailsDto>();
        CreateMap<CharacterWriteDto, Character>();
        CreateMap<Character, CharacterDto>();
    }
}