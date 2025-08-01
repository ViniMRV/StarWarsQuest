namespace StarWarsQuest.Api.Models;

public class PlanetDetails
{    public string? Terrain { get; set; }
    public Dictionary<string, bool>? Resources { get; set; }
    public List<string>? Inhabitants { get; set; }
}

