using System.Reflection;
using Conference.Api.Infrastructure.Constraints;
using Conference.Api.Infrastructure.Middleware.Extensions;
using Conference.Api.Infrastructure.OpenAPi;
using Conference.Api.Mappings;
using Conference.Data;
using Conference.Domain.Entities;
using Conference.Domain.Extensions;
using Conference.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // options.ValueProviderFactories.Add(new CommaQueryStringValueProviderFactory());
    // options.ReturnHttpNotAcceptable = true;
    // options.RespectBrowserAcceptHeader = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConferenceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConferenceDatabase"),
        m => m.MigrationsAssembly("Conference.Domain"));
});

builder.Services.AddScoped<ISpeakersRepository, SpeakersRepository>();
builder.Services.AddScoped<ISpeakersService, SpeakersService>();
builder.Services.AddScoped<ITalksRepository, TalksRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(SpeakerProfile));

builder.Services.AddRouting(options => { options.ConstraintMap.Add("email", typeof(EmailRouteConstraint)); });

builder.Services.AddApiVersioning(options => { })
    .AddApiExplorer(o =>
    {
        o.GroupNameFormat = "'v'VVV";
        o.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions()) //apiVersionDescriptionProvider.ApiVersionDescriptions
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }

        // options.RoutePrefix = string.Empty;
        // options.SwaggerEndpoint("");
    });

    app.MapScalarApiReference(options =>
    {
        foreach (var description in app.DescribeApiVersions()) //apiVersionDescriptionProvider.ApiVersionDescriptions
            options.WithOpenApiRoutePattern($"/swagger/{description.GroupName}/swagger.json");
    });
}

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    serviceScope.ServiceProvider?.GetService<ConferenceContext>()?.Database.EnsureCreated();
    serviceScope.ServiceProvider?.GetService<ConferenceContext>()?.EnsureSeeded();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseSecurityHeaders();

app.MapControllers();

app.Run();

// dotnet ef migrations add Initial --project Conference.Domain --output-dir Migrations --context ConferenceContext --startup-project Conference.Api