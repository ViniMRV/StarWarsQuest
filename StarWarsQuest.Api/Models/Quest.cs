using StarWarsQuest.Api.Models.Enums;

namespace StarWarsQuest.Api.Models;

public class Quest
{
    public int QuestId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public QuestStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
