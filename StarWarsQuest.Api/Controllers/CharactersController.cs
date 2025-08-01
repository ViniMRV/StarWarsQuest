using Microsoft.AspNetCore.Mvc;
using StarWarsQuest.Api.DTO.CharactersDTOs;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Services;

namespace StarWarsQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacterDTO>>> GetAll()
        {
            var characters = await _characterService.GetAll();

            if (!characters.Any()) 
                return NotFound("No characters were found");
            
            return Ok(characters);
        }

        [HttpGet("{id:int}", Name = "GetCharacter")]
        public async Task<ActionResult<Character>> GetById(int id)
        {
            var character = await _characterService.GetById(id);
            if (character == null)
                return NotFound("No character with this id was found");

            return Ok(character);

        }

        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter([FromBody] CharacterDTO character)
        {
            await _characterService.Create(character);
            return new CreatedAtRouteResult("GetCharacter", character);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Character>> DeleteCharacter(int id)
        {
            var result = await _characterService.Delete(id);

            if (!result)
                return NotFound("Unable to delete character with this id");

            return Ok("Character deleted successfully");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Character>> UpdateCharacter([FromBody] CharacterDTO character, [FromRoute] int id)
        {

            await _characterService.Update(character,id);

            return Ok(character);
        }

        [HttpGet("avaliable")]
        public async Task<ActionResult<List<CharacterDTO>>> FindAvaliables()
        {
            var characters = await _characterService.FindAvaliables();

            if (characters == null) { return NotFound("No avaliable characters were found"); }

            return Ok(characters);
        }

        [HttpGet("assignedquest/{id:int}")]
        public async Task<ActionResult<Quest>> GetAssignedQuest([FromRoute] int id)
        {
            var quest = await _characterService.GetAssignedQuest(id);
            if (quest == null) { return NotFound("This character has no quest"); }
            return Ok(quest);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Character>> GetByName([FromRoute] string name)
        {
            var character = await _characterService.GetByName(name);
            if (character == null) { return NotFound("No character was found with this name"); }
            return Ok(character);
        }
    }
}
