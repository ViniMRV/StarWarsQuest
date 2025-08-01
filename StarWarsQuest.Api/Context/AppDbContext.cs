using Microsoft.EntityFrameworkCore;
using StarWarsQuest.Api.Context.Mappers;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Character> characters { get; set; }
    public DbSet<Quest> quests { get; set; }
    public DbSet<Spaceship> spaceships { get; set; } 
    public DbSet<QuestAssociations> questAssociations { get; set; }
    public DbSet<Planet> planets { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        mb.ApplyConfiguration(new QuestMapper());
        mb.ApplyConfiguration(new SpaceshipMapper());
        mb.ApplyConfiguration(new CharacterMapper());
        mb.ApplyConfiguration(new QuestAssociationsMapper());
        mb.ApplyConfiguration(new PlanetMapper());

    }
}
