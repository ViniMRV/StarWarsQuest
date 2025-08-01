using Microsoft.EntityFrameworkCore;
using StarWarsQuest.Api.Context;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public class QuestRepository : IQuestRepository
{
    private readonly AppDbContext _context;

    public QuestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Quest> Create(Quest Quest)
    {
        _context.quests.Add(Quest);
        await _context.SaveChangesAsync();
        return Quest;
    }

    public async Task<Quest> Delete(int id)
    {
        var quest = await GetById(id);
        _context.quests.Remove(quest);
        await _context.SaveChangesAsync();
        return quest;
    }

    public async Task<List<Quest>> FindFinisheds()
    {
        return await _context.quests.Where(q=> q.Status == Models.Enums.QuestStatus.Finished).ToListAsync();
    }

    public async Task<List<Quest>> FindInProgress()
    {
        return await _context.quests.Where(q => q.Status == Models.Enums.QuestStatus.InProgress).ToListAsync();
    }

    public async Task<List<Quest>> FindToStart()
    {
        return await _context.quests.Where(q => q.Status == Models.Enums.QuestStatus.ToStart).ToListAsync();
    }

    public async Task<List<Quest>> GetAll()
    {
        return await _context.quests.ToListAsync();
    }

    public async Task<Quest> GetById(int id)
    {
        return await _context.quests.Where(q => q.QuestId == id).FirstOrDefaultAsync();
    }

    public async Task<Quest> Update(Quest Quest)
    {
        _context.Entry(Quest).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Quest;
    }

    public async Task<QuestAssociations> AssignParticipants(Quest quest, Character character, Spaceship spaceship)
    {
        QuestAssociations association = new QuestAssociations();

        association.CharacterId = character.CharacterId;
        association.QuestId = quest.QuestId;
        association.SpaceshipId = spaceship.SpaceshipId;

        _context.questAssociations.Add(association);
        await _context.SaveChangesAsync();
        return association;
    }

    public async Task<QuestAssociations> GetAssociationById(int id)
    {
        return await _context.questAssociations.FirstOrDefaultAsync(q => q.QuestId == id);
    }
}
