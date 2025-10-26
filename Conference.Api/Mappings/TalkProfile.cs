using AutoMapper;
using Conference.Api.Models;
using Conference.Domain.Entities;

namespace Conference.Api.Mappings;

public class TalkProfile : Profile
{
    public TalkProfile()
    {
        CreateMap<Talk, TalkModel>();
    }
}