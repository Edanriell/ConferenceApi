using Conference.Domain.Entities;

namespace Conference.Domain.Extensions;

public static class DbContextExtension
{
    public static void EnsureSeeded(this ConferenceContext context)
    {
        DataSeeder.SeedData(context);
    }
}