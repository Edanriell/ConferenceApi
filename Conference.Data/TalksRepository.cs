using Conference.Domain.Entities;

namespace Conference.Data;

public class TalksRepository : ITalksRepository
{
    private readonly ConferenceContext context;

    public TalksRepository(ConferenceContext context)
    {
        this.context = context;
    }

    public bool TalkExists(int id)
    {
        throw new NotImplementedException();
    }

    public Talk Add(Talk newTalk)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Talk talk)
    {
        throw new NotImplementedException();
    }

    public Talk Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Talk> GetAll()
    {
        throw new NotImplementedException();
    }

    public Talk Update(Talk talk)
    {
        throw new NotImplementedException();
    }

    public Talk GetTalk(int speakerId, int talkId)
    {
        return context.Talks
            .FirstOrDefault(c => c.SpeakerId == speakerId && c.Id == talkId);
    }

    public List<Talk> GetTalksForSpeaker(int speakerId)
    {
        if (speakerId == 0) throw new ArgumentNullException(nameof(speakerId));

        return context.Talks
            .Where(c => c.SpeakerId == speakerId)
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Talk GetTalk(int talkId)
    {
        return context.Talks
            .FirstOrDefault(c => c.Id == talkId);
    }
}