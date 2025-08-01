using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public interface ICharacterRepository
{
    Task<List<Character>> GetAll();
    Task<List<Character>> FindAvaliables();
    Task<Character> GetById(int id);
    Task<Quest> GetAssignedQuest(int id);
    Task<Character> Create(Character character);
    Task<Character> Update(Character character);
    Task<Character> Delete(Character character);

    Task<Character> GetByName(string name);
}
