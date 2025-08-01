using AutoMapper;
using StarWarsQuest.Api.DTO.SpaceshipsDTOs;
using StarWarsQuest.Api.DTO.QuestsDTOs;
using StarWarsQuest.Api.Http;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Repositories;

namespace StarWarsQuest.Api.Services;

public class SpaceshipService : ISpaceshipService
{
    private readonly ISpaceshipRepository _spaceshipRepository;
    private readonly IMapper _mapper;
    private readonly StarWarsClient _client;

    public SpaceshipService(ISpaceshipRepository spaceshipRepository, IMapper mapper, StarWarsClient client)
    {
        _spaceshipRepository = spaceshipRepository;
        _mapper = mapper;
        _client = client;
    }

    public async Task Create(SpaceshipDTO spaceshipDTO)
    {
        if (spaceshipDTO == null) 
                return;
        var spaceshipEntity = _mapper.Map<Spaceship> (spaceshipDTO);
        await _spaceshipRepository.Create(spaceshipEntity);

    }

    public async Task Delete(int id)
    {
        if(id == default)
            return;

        var spaceshipEntity = await _spaceshipRepository.GetById(id);
        await _spaceshipRepository.Delete(spaceshipEntity.SpaceshipId);
    }

    public async Task<List<SpaceshipInfosDTO>> FindAvaliables()
    {
        var spaceshipEntities = await _spaceshipRepository.FindAvaliables();
        return _mapper.Map<List<SpaceshipInfosDTO>>(spaceshipEntities);
    }

    public async Task<List<SpaceshipInfosDTO>> GetAll()
    {
        var spaceshipsEntities = await _spaceshipRepository.GetAll();
        return _mapper.Map<List<SpaceshipInfosDTO>>(spaceshipsEntities);
    }

    public async Task<QuestInfosDTO> GetAssignedQuest(int id)
    {
        var questEntity = await _spaceshipRepository.GetAssignedQuest(id);
        return _mapper.Map<QuestInfosDTO>(questEntity);
    }

    public async Task<SpaceshipInfosDTO> GetById(int id)
    {
        var spaceshipEntity = await _spaceshipRepository.GetById(id);
        return _mapper.Map<SpaceshipInfosDTO>(spaceshipEntity);
    }

    public async Task Update(SpaceshipDTO spaceshipDTO, int id)
    {
        if (spaceshipDTO == null)
            return;

        var spaceshipEntity = await _spaceshipRepository.GetById(id);
        if (spaceshipEntity == null) 
            return;

        spaceshipEntity.Name = spaceshipDTO.Name;

        await _spaceshipRepository.Update(spaceshipEntity);
    }

    public async Task<SpaceshipInfosDTO> GetByName(string name)
    {
        var spaceshipEntity = await _spaceshipRepository.GetByName(name);
        if (spaceshipEntity is not null)
        {
            return _mapper.Map<SpaceshipInfosDTO>(spaceshipEntity);
        }
        else
        {
            var response = await _client.GetSpaceship(name);

            if (response.Results is null)
                return null;

            Spaceship newSpaceshipEntity = new Spaceship();

            newSpaceshipEntity.Name = response.Results[0].Name;

            await _spaceshipRepository.Create(newSpaceshipEntity);

            return _mapper.Map<SpaceshipInfosDTO>(newSpaceshipEntity);
        }
    }
}
