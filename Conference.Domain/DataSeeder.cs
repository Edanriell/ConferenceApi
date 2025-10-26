using Conference.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Conference.Domain;

public static class DataSeeder
{
    public static void SeedData(ConferenceContext _context)
    {
        if (!_context.Speakers.Any())
        {
            _context.Speakers.AddRange(LoadSpeakers());
            _context.SaveChanges();
        }
    }

    private static List<Speaker> LoadSpeakers()
    {
        var jsonPath = @"D:\Projects\Conference.Api\Conference.Domain\data.json";
        using (var file = File.OpenText(jsonPath))
        {
            var serializer = new JsonSerializer();
            serializer.ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var speakers = (List<Speaker>)serializer.Deserialize(file, typeof(List<Speaker>));
            return speakers;
        }
    }
}