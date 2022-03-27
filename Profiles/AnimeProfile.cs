using aninja_character_service.Dtos;
using aninja_character_service.Models;
using AutoMapper;

namespace aninja_character_service.Profiles;

public class AnimeProfile : Profile
{
    public AnimeProfile()
    {
        CreateMap<AnimePublishedDto, Anime>()
            .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        
    }
}