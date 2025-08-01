using Microsoft.EntityFrameworkCore;
using StarWarsQuest.Api.Context;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _context;
        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Character> Create(Character character)
        {
            _context.characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> Delete(Character character)
        {            
            _context.characters.Remove(character);
            await _context.SaveChangesAsync();
            return character;
            
        }

        public async Task<List<Character>> FindAvaliables()
        {
            var characters = await _context.characters
                .Where(c =>
                    !_context.questAssociations.Any(qa => qa.CharacterId == c.CharacterId) 
                    || 
                    _context.questAssociations
                        .Where(qa => qa.CharacterId == c.CharacterId)
                        .All(qa => qa.Quest.Status == Models.Enums.QuestStatus.Finished)) 
                .ToListAsync();

            return characters;
        }

        public async Task<List<Character>> GetAll()
        {
            return await _context.characters.ToListAsync();
        }

        public async Task<Quest> GetAssignedQuest(int id)
        {
            return await _context.questAssociations
                            .Where(qa => qa.CharacterId == id &&
                                         qa.Quest.Status != Models.Enums.QuestStatus.Finished)
                            .Select(qa => qa.Quest)
                            .FirstOrDefaultAsync();
        }

        public async Task<Character> GetById(int id)
        {
            return await _context.characters.Where(c=> c.CharacterId == id).FirstOrDefaultAsync();
        }

        public async Task<Character> Update(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> GetByName(string name)
        {
            string filterName = $"%{name.ToLower()}%";
            return await _context.characters.FirstOrDefaultAsync(c => EF.Functions.Like(c.Name.ToLower(),filterName));
        }
    }
}
