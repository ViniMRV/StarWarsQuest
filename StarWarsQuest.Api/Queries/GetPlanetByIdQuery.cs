using MediatR;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Queries;

public class GetPlanetByIdQuery : IRequest<Planet?>
{
    public int Id { get; }

    public GetPlanetByIdQuery(int id)
    {
        Id = id;
    }
}
