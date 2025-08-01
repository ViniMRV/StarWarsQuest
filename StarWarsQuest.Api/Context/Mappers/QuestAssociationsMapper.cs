using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Context.Mappers;

public class QuestAssociationsMapper : IEntityTypeConfiguration<QuestAssociations>
{
    public void Configure(EntityTypeBuilder<QuestAssociations> builder)
    {
        builder.ToTable("questassociations");

        builder.HasKey(qa => new { qa.CharacterId, qa.QuestId, qa.SpaceshipId });

        builder.Property(qa => qa.CharacterId)
               .HasColumnName("characterid");

        builder.Property(qa => qa.QuestId)
               .HasColumnName("questid");

        builder.Property(qa => qa.SpaceshipId)
               .HasColumnName("spaceshipid");

        builder.HasOne(qa => qa.Character)
               .WithMany()
               .HasForeignKey(qa => qa.CharacterId);

        builder.HasOne(qa => qa.Quest)
               .WithMany()
               .HasForeignKey(qa => qa.QuestId);

        builder.HasOne(qa => qa.Spaceship)
               .WithMany()
               .HasForeignKey(qa => qa.SpaceshipId);

    }
}
