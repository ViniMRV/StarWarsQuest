using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Context.Mappers;

public class SpaceshipMapper : IEntityTypeConfiguration<Spaceship>
{
    public void Configure(EntityTypeBuilder<Spaceship> builder)
    {
        builder.ToTable("spaceships");

        builder.HasKey(s => s.SpaceshipId);

        builder.Property(s => s.SpaceshipId)
               .HasColumnName("spaceshipid");

        builder.Property(s => s.Name)
               .HasColumnName("name")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(s => s.SpaceshipId).ValueGeneratedOnAdd();
    }
}
