using Conference.Domain.Entities;

namespace Conference.Data;

public interface ISpeakersRepository
{
    Speaker Add(Speaker newSpeaker);
    IQueryable<Speaker> GetAll();
    Speaker Get(int id);
    Speaker Update(Speaker speaker);
    bool Delete(Speaker speaker);
    bool SpeakerExists(int id);
    bool IsEmailUnique(string email);
}