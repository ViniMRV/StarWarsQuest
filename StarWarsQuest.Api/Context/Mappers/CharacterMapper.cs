using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Context.Mappers;

public class CharacterMapper : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("characters"); // Ensure correct table name

        builder.HasKey(c => c.CharacterId);

        builder
            .Property(c => c.CharacterId)
            .HasColumnName("characterid"); 

        builder
            .Property(c => c.Name)
            .HasColumnName("name")         
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.CharacterId).ValueGeneratedOnAdd();
    }
}
