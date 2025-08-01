using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public interface IQuestRepository
{
    Task<List<Quest>> GetAll();
    Task<List<Quest>> FindToStart();
    Task<List<Quest>> FindInProgress();
    Task<List<Quest>> FindFinisheds();
    Task<QuestAssociations> AssignParticipants(Quest quest, Character character, Spaceship spaceship);
    Task<QuestAssociations> GetAssociationById(int id);
    Task<Quest> GetById(int id);
    Task<Quest> Create(Quest Quest);
    Task<Quest> Update(Quest Quest);
    Task<Quest> Delete(int id);
}
