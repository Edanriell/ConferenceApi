using Conference.Domain.Entities;

namespace Conference.Service;

public interface ISpeakersService
{
    Speaker Add(Speaker newSpeaker);
    IEnumerable<Speaker> GetAll();
    Speaker Get(int id);
    Speaker Update(Speaker speaker);
    bool Delete(Speaker speaker);
    bool CheckIfExists(int id);
    bool IsEmailUnique(string email);
}