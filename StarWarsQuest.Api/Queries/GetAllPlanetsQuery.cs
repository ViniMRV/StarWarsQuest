using MediatR;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Queries;

public class GetAllPlanetsQuery:IRequest<List<Planet>>
{

}
