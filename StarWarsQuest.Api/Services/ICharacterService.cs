using StarWarsQuest.Api.DTO.CharactersDTOs;
using StarWarsQuest.Api.DTO.QuestsDTOs;

namespace StarWarsQuest.Api.Services;

public interface ICharacterService
{
    Task<List<CharacterDTO>> GetAll();
    Task<List<CharacterDTO>> FindAvaliables();
    Task<CharacterDTO> GetById(int id);
    Task<CharacterInfosDTO> GetByName(string name);
    Task<QuestInfosDTO> GetAssignedQuest(int id);
    Task Create(CharacterDTO characterDTO);
    Task Update(CharacterDTO characterDTO, int id);
    Task<Boolean> Delete(int id);
}
