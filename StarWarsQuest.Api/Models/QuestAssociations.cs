namespace StarWarsQuest.Api.Models;

public class QuestAssociations
{
    public int CharacterId { get; set; }
    public int QuestId { get; set; }
    public int SpaceshipId { get; set; }

    public Character Character { get; set; }
    public Quest Quest { get; set; }
    public Spaceship Spaceship { get; set; }
}

