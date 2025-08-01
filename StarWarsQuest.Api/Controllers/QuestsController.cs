using Microsoft.AspNetCore.Mvc;
using StarWarsQuest.Api.DTO.QuestsDTOs;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Services;

namespace StarWarsQuest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestsController : ControllerBase
{
    private readonly IQuestService _questService;
    private readonly ISpaceshipService _spaceshipService;
    private readonly ICharacterService _characterService;

    public QuestsController(IQuestService questService, ISpaceshipService spaceshipService, ICharacterService characterService)
    {
        _questService = questService;
        _spaceshipService = spaceshipService;
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Quest>>> GetAll()
    {
        var quests = await _questService.GetAll();
        if (!quests.Any()) { return NotFound("No quests were found"); }
        return Ok(quests);
        
    }

    [HttpGet("finisheds")]
    public async Task<ActionResult<List<Quest>>> GetAllFinisheds()
    {
        var quests = await _questService.FindFinished();
        if (!quests.Any()) { return NotFound("No finisheds quests were found"); }
        return Ok(quests);

    }

    [HttpGet("started")]
    public async Task<ActionResult<List<Quest>>> GetAllStarteds()
    {
        var quests = await _questService.FindInProgress();
        if (!quests.Any()) { return NotFound("No started quests were found"); }
        return Ok(quests);

    }

    [HttpGet("tostart")]
    public async Task<ActionResult<List<Quest>>> GetAllNonStarteds()
    {
        var quests = await _questService.FindToStart();
        if (!quests.Any()) { return NotFound("No quests to start were found"); }
        return Ok(quests);

    }

    [HttpGet("{id:int}",Name = "GetQuest")]
    public async Task<ActionResult<Quest>> GetById(int id)
    {
        var quest = await _questService.GetById(id);
        if (quest == null) { return NotFound("There is no quest with this ID"); }
        return Ok(quest);
    }

    [HttpPost]
    public async Task<ActionResult<Quest>> CreateQuest([FromBody] CreateQuestDTO quest)
    {
        if (quest == null) { return BadRequest("There was no quest in the request body"); }
        await _questService.Create(quest);
        return new CreatedAtRouteResult("GetQuest", quest);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Quest>> DeleteQuest([FromRoute] int id)
    {
        var questDto = await _questService.GetById(id);
        if (questDto == null)
        {
            return NotFound("Quest not found");
        }

        await _questService.Delete(id);

        return Ok(questDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Quest>> UpdateQuest([FromBody] UpdateQuestDTO quest, [FromRoute] int id)
    {

        await _questService.Update(quest,id);

        return Ok(quest);
    }

    [HttpPatch("start/{id:int}")]
    public async Task<ActionResult<Quest>> StartQuest(int id)
    {
        var updatedQuest = await _questService.StartQuest(id);

        if (updatedQuest is null) return NotFound("The quest with this ID is already in progress or finished. Or there is no quest with this id");

        return Ok(updatedQuest);
    }

    [HttpPatch("end/{id:int}")]
    public async Task<ActionResult<Quest>> EndQuest(int id)
    {
        var updatedQuest = await _questService.EndQuest(id);

        if (updatedQuest is null) 
            return NotFound("The quest with this ID is already finished or never started. Or there is no quest with this id");

        return Ok(updatedQuest);
    }

    [HttpPost("assign")]
    public async Task<ActionResult<QuestAssociationsDTO>> AssignParticipants([FromBody] QuestAssociationsDTO association)
    {
        if(association == null) { return BadRequest("The request body was empty"); }

        var characterquest = await _characterService.GetAssignedQuest(association.CharacterId);
        var spaceshipquest = await _spaceshipService.GetAssignedQuest(association.SpaceshipId);

        if(characterquest is not null) { return BadRequest("This character is already on a quest"); }
        if(spaceshipquest is not null) { return BadRequest("This spaceship is already on a quest"); }

        var existingAssociation = await _questService.GetAssociationById(association.QuestId);

        if (existingAssociation is not null)
        {
            if(existingAssociation.SpaceshipId != association.SpaceshipId){ return BadRequest("A different spaceship is already assigned to this quest");}
            if(existingAssociation.CharacterId == association.CharacterId){ return BadRequest("This character is already assigned to this quest"); }

        }
        
        var result = await _questService.AssignParticipants(association.QuestId, association.CharacterId, association.SpaceshipId);

        return Ok(result);
    }


}
