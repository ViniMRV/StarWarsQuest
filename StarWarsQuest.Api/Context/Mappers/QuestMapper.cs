using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Context.Mappers
{
    public class QuestMapper : IEntityTypeConfiguration<Quest>
    {
        public void Configure(EntityTypeBuilder<Quest> builder)
        {
            builder.ToTable("quests"); 

            builder.HasKey(q => q.QuestId);

            builder.Property(q => q.QuestId)
                   .HasColumnName("questid");

            builder.Property(q => q.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(q => q.Description)
                   .HasColumnName("description")
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(q => q.Status)
                   .HasColumnName("status")
                   .HasColumnType("int")
                   .IsRequired();

            builder.Property(q => q.StartDate)
                .HasColumnName("startdate")
                .HasColumnType("date");

            builder.Property(q => q.EndDate)
                .HasColumnName("enddate")
                .HasColumnType("date");

            builder.Property(q => q.QuestId).ValueGeneratedOnAdd();



        }
    }
}
