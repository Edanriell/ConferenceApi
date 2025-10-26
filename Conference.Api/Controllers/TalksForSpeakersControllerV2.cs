using Asp.Versioning;
using AutoMapper;
using Conference.Api.Models;
using Conference.Data;
using Conference.Service;
using Microsoft.AspNetCore.Mvc;

namespace Conference.Api.Controllers;

[ApiVersion("2.0")]
[Route("api/speakers/{speakerId}/talks")]
[ApiController]
public class TalksForSpeakersControllerV2 : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ISpeakersService speakersService;
    private readonly ITalksRepository talksRepository;

    public TalksForSpeakersControllerV2(ITalksRepository talksRepository,
        ISpeakersService speakersService, IMapper mapper
    )
    {
        this.talksRepository = talksRepository;
        this.speakersService = speakersService;
        this.mapper = mapper;
    }


    [HttpGet("{talkId}", Name = "GetTalkForSpeaker")]
    public ActionResult<TalkModel> GetTalksForSpeaker(int speakerId, int talkId)
    {
        if (!speakersService.CheckIfExists(speakerId)) return NotFound();

        var talkForSpeaker = talksRepository.GetTalk(speakerId, talkId);

        if (talkForSpeaker == null) return NotFound();
        var talk = talksRepository.GetTalksForSpeaker(speakerId);
        var talkModel = mapper.Map<IEnumerable<TalkModel>>(talk);
        return Ok(talkModel);
    }
}