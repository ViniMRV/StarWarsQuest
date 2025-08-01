using Microsoft.EntityFrameworkCore;
using StarWarsQuest.Api.Context;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public class SpaceshipRepository : ISpaceshipRepository
{
    private readonly AppDbContext _context;

    public SpaceshipRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Spaceship> Create(Spaceship spaceship)
    {
        _context.spaceships.Add(spaceship);
        await _context.SaveChangesAsync();
        return spaceship;
    }

    public async Task<Spaceship> Delete(int id)
    {
        var spaceship = await GetById(id);
        _context.spaceships.Remove(spaceship);
        await _context.SaveChangesAsync();
        return spaceship;
    }

    public async Task<List<Spaceship>> FindAvaliables()
    {
        return await _context.spaceships.Where(s=>
            !_context.questAssociations.Any(qa => qa.SpaceshipId ==  s.SpaceshipId)
            ||
            _context.questAssociations
                    .Where(qa => qa.SpaceshipId == s.SpaceshipId)
                    .All(qa => qa.Quest.Status == Models.Enums.QuestStatus.Finished))
                .ToListAsync();
    }

    public async Task<List<Spaceship>> GetAll()
    {
        return await _context.spaceships.ToListAsync();
    }

    public async Task<Quest> GetAssignedQuest(int id)
    {
        return await _context.questAssociations
                            .Where(qa => qa.SpaceshipId == id &&
                                         qa.Quest.Status != Models.Enums.QuestStatus.Finished)
                            .Select(qa => qa.Quest)
                            .FirstOrDefaultAsync();
    }

    public async Task<Spaceship> GetById(int id)
    {
        return await _context.spaceships.Where(s => s.SpaceshipId == id).FirstOrDefaultAsync();
    }

    public async Task<Spaceship> Update(Spaceship spaceship)
    {
        _context.Entry(spaceship).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return spaceship;
    }

    public async Task<Spaceship> GetByName(string name)
    {
        return await _context.spaceships.Where(s => s.Name.ToLower().StartsWith(name.ToLower())).FirstOrDefaultAsync();
    }
}
