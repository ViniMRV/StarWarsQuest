using Microsoft.AspNetCore.Mvc;
using StarWarsQuest.Api.DTO.SpaceshipsDTOs;
using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Services;

namespace StarWarsQuest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceshipsController : ControllerBase
    {
        private readonly ISpaceshipService _spaceshipService;

        public SpaceshipsController(ISpaceshipService spaceshipService)
        {
            _spaceshipService = spaceshipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Spaceship>>> GetAll()
        {
            var spaceships = await _spaceshipService.GetAll();
            if (!spaceships.Any()) { return NotFound("No spaceships were found"); }
            return Ok(spaceships);
        }

        [HttpGet("{id:int}", Name = "GetSpaceship")]
        public async Task<ActionResult<Spaceship>> GetById(int id)
        {
            var spaceship = await _spaceshipService.GetById(id);
            if (spaceship == null) { return NotFound("No spaceship was found with this id"); }
            return Ok(spaceship);
        }

        [HttpGet("avaliable")]
        public async Task<ActionResult<List<Spaceship>>> GetAvaliableShips()
        {
            var spaceships = await _spaceshipService.FindAvaliables();
            if (!spaceships.Any()) { return NotFound("No avaliable spaceships were found"); }
            return Ok(spaceships);
        }

        [HttpGet("assigned/{id:int}")]
        public async Task<ActionResult<Quest>> GetAssignedQuest([FromRoute] int id)
        {
            var quest = await _spaceshipService.GetAssignedQuest(id);
            if (quest is null) { return NotFound("This spaceship has no quests assigned at the moment"); }
            return Ok(quest);
        }

        [HttpPost]
        public async Task<ActionResult<Spaceship>> Create([FromBody] SpaceshipDTO spaceship)
        {
            if (spaceship == null) { return BadRequest("There was no spaceship in the request body"); }
            await _spaceshipService.Create(spaceship);
            return new CreatedAtRouteResult("GetSpaceship", spaceship);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Spaceship>> Update([FromBody] SpaceshipDTO spaceship, [FromRoute] int id)
        {

            if (spaceship is null)
                return BadRequest("There was no spaceship in the request body");

            await _spaceshipService.Update(spaceship,id);

            return Ok(spaceship);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Spaceship>> Delete([FromRoute] int id)
        {
            var spaceshipDto = await _spaceshipService.GetById(id);
            if (spaceshipDto == null)
            {
                return NotFound("Spaceship not found");
            }

            await _spaceshipService.Delete(id);

            return Ok(spaceshipDto);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Character>> GetByName([FromRoute] string name)
        {
            var spaceship = await _spaceshipService.GetByName(name);
            if (spaceship == null) { return NotFound("No spaceship was found with this name"); }
            return Ok(spaceship);
        }

    }
}
