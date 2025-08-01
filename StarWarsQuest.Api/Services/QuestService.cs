using AutoMapper;
using StarWarsQuest.Api.Repositories;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.DTO.QuestsDTOs;

namespace StarWarsQuest.Api.Services;

public class QuestService : IQuestService
{
    private readonly IQuestRepository _questRepository;
    private readonly ISpaceshipRepository _spaceshipRepository;
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public QuestService(IQuestRepository questRepository, ISpaceshipRepository spaceshipRepository, ICharacterRepository characterRepository, IMapper mapper)
    {
        _questRepository = questRepository;
        _spaceshipRepository = spaceshipRepository;
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task Create(CreateQuestDTO questDTO)
    {
        if (questDTO == null)
            return;

        var QuestEntity = _mapper.Map<Quest>(questDTO);
        QuestEntity.Status = Models.Enums.QuestStatus.ToStart;
        await _questRepository.Create(QuestEntity);

    }

    public async Task Delete(int id)
    {
        if (id == default) 
            return;

        var QuestEntity = _questRepository.GetById(id).Result;
        await _questRepository.Delete(QuestEntity.QuestId);
    }

    public async Task<List<QuestInfosDTO>> FindFinished()
    {
        var QuestEntity = await _questRepository.FindFinisheds();
        return _mapper.Map<List<QuestInfosDTO>>(QuestEntity);
    }

    public async Task<List<QuestInfosDTO>> FindToStart()
    {
        var QuestEntity = await _questRepository.FindToStart();
        return _mapper.Map<List<QuestInfosDTO>>(QuestEntity);
    }

    public async Task<List<QuestInfosDTO>> FindInProgress()
    {
        var QuestEntity = await _questRepository.FindInProgress();
        return _mapper.Map<List<QuestInfosDTO>>(QuestEntity);
    }

    public async Task<List<QuestInfosDTO>> GetAll()
    {
        var QuestsEntity = await _questRepository.GetAll();
        return _mapper.Map<List<QuestInfosDTO>>(QuestsEntity);
    }

    public async Task<QuestInfosDTO> GetById(int id)
    {
        var QuestEntity = await _questRepository.GetById(id);
        return _mapper.Map<QuestInfosDTO>(QuestEntity);
    }

    public async Task Update(UpdateQuestDTO questDTO, int id)
    {
        if(questDTO == null)
            return;

        var existingQuest = await _questRepository.GetById(id);
        if (existingQuest == null) 
            return;

        existingQuest.Status = questDTO.Status;
        existingQuest.StartDate = questDTO.StartDate;
        existingQuest.EndDate = questDTO.EndDate;

        await _questRepository.Update(existingQuest);
    }

    public async Task<QuestAssociationsDTO> AssignParticipants(int QuestId, int CharacterId, int SpaceshipId)
    {

        var questEntity = await _questRepository.GetById(QuestId);
        var characterEntity = await _characterRepository.GetById(CharacterId);
        var spaceshipEntity = await _spaceshipRepository.GetById(SpaceshipId);

        if (questEntity == null) 
            return null;

        if (spaceshipEntity == null)
            return null;

        if (characterEntity == null)
            return null;
        
        var associationEntity = await _questRepository.AssignParticipants(questEntity, characterEntity, spaceshipEntity);

        
        var resultDto = _mapper.Map<QuestAssociationsDTO>(associationEntity);
        return resultDto;
    }

    public async Task<QuestAssociationsDTO> GetAssociationById(int id)
    {
        var QuestEntity = await _questRepository.GetAssociationById(id);
        return _mapper.Map<QuestAssociationsDTO>(QuestEntity);
    }

    public async Task<QuestInfosDTO> StartQuest(int id)
    {
        var existingQuest = await _questRepository.GetById(id);
        if (existingQuest == null)
            return null;

        if (existingQuest.Status != Models.Enums.QuestStatus.ToStart)
            return null;

        existingQuest.Status = Models.Enums.QuestStatus.InProgress;
        existingQuest.StartDate = DateTime.Now;

        await _questRepository.Update(existingQuest);
        
        return _mapper.Map<QuestInfosDTO>(existingQuest);
    }

    public async Task<QuestInfosDTO> EndQuest(int id)
    {
        var existingQuest = await _questRepository.GetById(id);
        if (existingQuest == null)
            return null;

        Console.WriteLine("\n\n\n\nA");
        Console.WriteLine(existingQuest.Status.ToString());
        Console.WriteLine("\n\n\n\nB");
        if (existingQuest.Status != Models.Enums.QuestStatus.InProgress)
            return null;

        existingQuest.Status = Models.Enums.QuestStatus.Finished;
        existingQuest.EndDate = DateTime.Now;

        await _questRepository.Update(existingQuest);
        
        return _mapper.Map<QuestInfosDTO>(existingQuest);
    }
}
