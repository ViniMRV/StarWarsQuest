using StarWarsQuest.Api.DTO.QuestsDTOs;
using StarWarsQuest.Api.DTO.SpaceshipsDTOs;

namespace StarWarsQuest.Api.Services;

public interface ISpaceshipService
{
    Task<List<SpaceshipInfosDTO>> GetAll();
    Task<List<SpaceshipInfosDTO>> FindAvaliables();
    Task<SpaceshipInfosDTO> GetById(int id);
    Task<SpaceshipInfosDTO> GetByName(string name);
    Task<QuestInfosDTO> GetAssignedQuest(int id);
    Task Create(SpaceshipDTO spaceshipDTO);
    Task Update(SpaceshipDTO spaceshipDTO, int id);
    Task Delete(int id);
}
