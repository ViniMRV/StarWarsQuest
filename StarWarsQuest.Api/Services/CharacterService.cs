using AutoMapper;
using StarWarsQuest.Api.DTO.CharactersDTOs;
using StarWarsQuest.Api.DTO.QuestsDTOs;
using StarWarsQuest.Api.Http;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Repositories;

namespace StarWarsQuest.Api.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;
    private readonly StarWarsClient _client;

    public CharacterService(ICharacterRepository characterRepository, IMapper mapper, StarWarsClient client)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
        _client = client;
    }

    public async Task Create(CharacterDTO characterDTO)
    {
        if (characterDTO == null)
            return;

        var characterEntity = _mapper.Map<Character>(characterDTO);
        await _characterRepository.Create(characterEntity);
    }

    public async Task<Boolean> Delete(int id)
    {

        var characterEntity = await _characterRepository.GetById(id);
        if (characterEntity is null)
            return false;

        await _characterRepository.Delete(characterEntity);
        return true;
    }

    public async Task<List<CharacterDTO>> FindAvaliables()
    {
        var charactersEntity = await _characterRepository.FindAvaliables();
        return _mapper.Map<List<CharacterDTO>>(charactersEntity);
    }

    public async Task<List<CharacterDTO>> GetAll()
    {
        var charactersEntity = await _characterRepository.GetAll();
        return _mapper.Map<List<CharacterDTO>>(charactersEntity);
    }

    public async Task<QuestInfosDTO> GetAssignedQuest(int id)
    {
        var questEntity = await _characterRepository.GetAssignedQuest(id);
        return _mapper.Map<QuestInfosDTO>(questEntity);
    }

    public async Task<CharacterDTO> GetById(int id)
    {
        var CharacterEntity = await _characterRepository.GetById(id);
        return _mapper.Map<CharacterDTO>(CharacterEntity);
    }

    public async Task<CharacterInfosDTO> GetByName(string name)
    {        
        var characterEntity = await _characterRepository.GetByName(name);
        if(characterEntity is not null)
        {
            return _mapper.Map<CharacterInfosDTO>(characterEntity);
        }
        else
        {
            var response = await _client.GetCharacter(name);

            if (response.Results is null || response.Results.Count == 0 ) 
                return null;

            Character newCharacterEntity = new Character();

            newCharacterEntity.Name = response.Results.FirstOrDefault().Name;

            await _characterRepository.Create(newCharacterEntity);

            return _mapper.Map<CharacterInfosDTO>(newCharacterEntity);
        }
    }


    public async Task Update(CharacterDTO characterDTO, int id)
    {
        if (characterDTO == null)
            return;

        var charaterEntity = await _characterRepository.GetById(id);

        if (charaterEntity is null)
            return;

        charaterEntity.Name = characterDTO.Name;

        await _characterRepository.Update(charaterEntity);
    }
}
