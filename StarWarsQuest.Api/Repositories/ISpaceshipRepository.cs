using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public interface ISpaceshipRepository
{
    Task<List<Spaceship>> GetAll();
    Task<List<Spaceship>> FindAvaliables();
    Task<Spaceship> GetById(int id);
    Task<Spaceship> GetByName(string name);
    Task<Quest> GetAssignedQuest(int id);
    Task<Spaceship> Create(Spaceship spaceship);
    Task<Spaceship> Update(Spaceship spaceship);
    Task<Spaceship> Delete(int id);
}
