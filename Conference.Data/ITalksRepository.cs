using Conference.Domain.Entities;

namespace Conference.Data;

public interface ITalksRepository
{
    Talk Add(Talk newTalk);
    IQueryable<Talk> GetAll();
    Talk Get(int id);
    Talk Update(Talk talk);
    bool Delete(Talk talk);
    bool TalkExists(int id);
    List<Talk> GetTalksForSpeaker(int speakerId);
    Talk GetTalk(int speakerId, int talkId);
}