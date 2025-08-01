using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarWarsQuest.Api.Behaviors;
using StarWarsQuest.Api.Context;
using StarWarsQuest.Api.Http;
using StarWarsQuest.Api.Repositories;
using StarWarsQuest.Api.Services;
using StarWarsQuest.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient<StarWarsClient>(client =>
{
    client.BaseAddress = new Uri("https://swapi.dev/api/");
})

.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});



builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
builder.Services.AddScoped<IQuestRepository, QuestRepository>();
builder.Services.AddScoped<ISpaceshipRepository, SpaceshipRepository>();
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IQuestService, QuestService>();
builder.Services.AddScoped<ISpaceshipService, SpaceshipService>();

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>)
);
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();