namespace Conference.Domain.Entities;

public class Talk
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? SpeakerId { get; set; }
    public virtual Speaker? Speaker { get; set; }
}