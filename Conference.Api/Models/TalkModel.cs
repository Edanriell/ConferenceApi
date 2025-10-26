namespace Conference.Api.Models;

public class TalkModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}