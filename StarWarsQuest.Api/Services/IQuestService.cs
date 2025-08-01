using StarWarsQuest.Api.DTO.QuestsDTOs;

namespace StarWarsQuest.Api.Services;

public interface IQuestService
{
    Task<List<QuestInfosDTO>> GetAll();
    Task<List<QuestInfosDTO>> FindToStart();
    Task<List<QuestInfosDTO>> FindInProgress();
    Task<List<QuestInfosDTO>> FindFinished();
    Task<QuestInfosDTO> GetById(int id);
    Task<QuestAssociationsDTO> AssignParticipants(int QuestId, int CharacterId, int SpaceshipId);
    Task<QuestAssociationsDTO> GetAssociationById(int id);
    Task Create(CreateQuestDTO questDTO);
    Task Update(UpdateQuestDTO questDTO, int id);
    Task Delete(int id);
    Task<QuestInfosDTO> StartQuest(int id);
    Task<QuestInfosDTO> EndQuest(int id);
}
