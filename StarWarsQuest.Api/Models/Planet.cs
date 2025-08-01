namespace StarWarsQuest.Api.Models;

public class Planet
{
    public int PlanetId { get; set; }
    public string Name { get; set; }
    public string Climate { get; set; }
    public int Population { get; set; }
    public PlanetDetails? Details { get; set; }
}
