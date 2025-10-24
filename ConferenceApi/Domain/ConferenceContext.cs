using Microsoft.EntityFrameworkCore;

namespace ConferenceApi.Domain;

public class ConferenceContext : DbContext
{
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Talk> Talks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Conference;Trusted_Connection=True");
    }
}