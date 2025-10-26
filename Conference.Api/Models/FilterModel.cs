namespace Conference.Api.Models;

public class FilterModel
{
    public string PrefferedAirport { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public SpeakerAddress Address { get; set; }
    public List<string> Countries { get; set; }
}