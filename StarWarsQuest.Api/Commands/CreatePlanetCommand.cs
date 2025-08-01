using MediatR;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Commands;

public class CreatePlanetCommand: IRequest<int>
{
    public CreatePlanetCommand(string name, string climate, int population, PlanetDetails details)
    {
        Name = name;
        Climate = climate;
        Population = population;
        Details = details;
    }

    public string Name { get; set; }
    public string Climate { get; set; }
    public int Population { get; set; }
    public PlanetDetails? Details { get; set; }


}
