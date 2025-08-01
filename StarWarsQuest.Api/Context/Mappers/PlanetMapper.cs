using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsQuest.Api.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StarWarsQuest.Api.Context.Mappers;

public class PlanetMapper : IEntityTypeConfiguration<Planet>
{
    public void Configure(EntityTypeBuilder<Planet> builder)
    {
        builder.ToTable("planets");

        builder.HasKey(p => p.PlanetId);

        builder
            .Property(p => p.PlanetId)
            .HasColumnName("planetid");

        builder
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(40)
            .IsRequired();

        builder
            .Property(p => p.Climate)
            .IsRequired();

        builder
            .Property(p => p.Population)
            .IsRequired();

        
        builder.Property(p => p.Details)
              .HasColumnType("jsonb")
              .HasConversion(
                  details => JsonSerializer.Serialize(details, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
                  details => JsonSerializer.Deserialize<PlanetDetails>(details, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
              );


        builder.Property(p => p.PlanetId).ValueGeneratedOnAdd();
    }
}
