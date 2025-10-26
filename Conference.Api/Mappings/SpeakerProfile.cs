using AutoMapper;
using Conference.Api.Models;
using Conference.Domain.Entities;

namespace Conference.Api.Mappings;

public class SpeakerProfile : Profile
{
    public SpeakerProfile()
    {
        CreateMap<Speaker, SpeakerModel>();
        CreateMap<Speaker, SpeakerModelV2>();
        CreateMap<SpeakerModel, Speaker>();
    }
}