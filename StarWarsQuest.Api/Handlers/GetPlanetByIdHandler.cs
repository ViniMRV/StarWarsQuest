using MediatR;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Queries;
using StarWarsQuest.Api.Repositories;

namespace StarWarsQuest.Api.Handlers;

public class GetPlanetByIdHandler : IRequestHandler<GetPlanetByIdQuery, Planet?>
{
    private readonly IPlanetRepository _repository;

    public GetPlanetByIdHandler(IPlanetRepository repository)
    {
        _repository = repository;
    }

    public async Task<Planet?> Handle(GetPlanetByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.Id);
    }



}
