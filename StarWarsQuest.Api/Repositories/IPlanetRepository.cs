using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public interface IPlanetRepository
{
    Task<List<Planet>> GetAll();
    Task<Planet> GetById(int id);
    Task<Planet>Update(int id, Planet planet);
    Task<Planet>Create(Planet planet);
    Task<Planet> Delete(int id);
    Task<Planet> GetByName(string name);

}
