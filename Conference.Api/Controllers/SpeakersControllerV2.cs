using Asp.Versioning;
using AutoMapper;
using Conference.Api.Models;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Api.Controllers;

[Route("api/speakers")]
[ApiVersion("2.0")]
[ApiController]
public class SpeakersControllerV2 : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ISpeakersService speakersService;

    public SpeakersControllerV2(ISpeakersService speakersService, IMapper mapper)
    {
        this.speakersService = speakersService;
        this.mapper = mapper;
    }


    [HttpGet("{id}", Name = "GetSpeakerById2")]
    public ActionResult<SpeakerModelV2> GetSpeakerByIdV2(int id)
    {
        var speakerToReturn = speakersService.Get(id);
        if (speakerToReturn == null) return NotFound();
        return Ok(mapper.Map<SpeakerModelV2>(speakerToReturn));
    }
}