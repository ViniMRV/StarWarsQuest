using MediatR;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Queries;
using StarWarsQuest.Api.Repositories;

namespace StarWarsQuest.Api.Handlers;

public class GetAllPlanetsHandler : IRequestHandler<GetAllPlanetsQuery, List<Planet>>
{
    private readonly IPlanetRepository _repository;

    public GetAllPlanetsHandler(IPlanetRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Planet>> Handle(GetAllPlanetsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll();
    }
}
