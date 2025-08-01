using MediatR;
using StarWarsQuest.Api.Commands;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Repositories;

namespace StarWarsQuest.Api.Handlers
{
    public class CreatePlanetHandler : IRequestHandler<CreatePlanetCommand, int>
    {
        private readonly IPlanetRepository _repository;

        public CreatePlanetHandler(IPlanetRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreatePlanetCommand command, CancellationToken cancellationToken)
        {
            var planet = new Planet
            {
                Name = command.Name,
                Population = command.Population,
                Climate = command.Climate,
                Details = command.Details
            };

            await _repository.Create(planet);

            return planet.PlanetId;
        }
    }
}
