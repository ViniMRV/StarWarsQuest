using Microsoft.EntityFrameworkCore;
using StarWarsQuest.Api.Context;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.Repositories;

public class PlanetRepository : IPlanetRepository
{
    private readonly AppDbContext _context;

    public PlanetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Planet> Create(Planet planet)
    {
        _context.planets.Add(planet);
        await _context.SaveChangesAsync();
        return planet;
    }

    public async Task<Planet> Delete(int id)
    {
        var planet = await GetById(id);
        
        if (planet is null) 
            return null;

        _context.planets.Remove(planet);
        await _context.SaveChangesAsync();
        return planet;

    }

    public async Task<List<Planet>> GetAll()
    {
        return await _context.planets.ToListAsync();
    }

    public async Task<Planet> GetById(int id)
    {
        return await _context.planets.FirstOrDefaultAsync(p => p.PlanetId == id);
    }

    public async Task<Planet> GetByName(string name)
    {
        return await _context.planets.FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<Planet> Update(int id, Planet planet)
    {
        _context.Entry(planet).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return planet;

    }
}
