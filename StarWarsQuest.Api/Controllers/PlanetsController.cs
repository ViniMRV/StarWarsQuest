using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsQuest.Api.Commands;
using StarWarsQuest.Api.Queries;

namespace StarWarsQuest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlanetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePlanetCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new {id});
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var planet = await _mediator.Send(new GetPlanetByIdQuery(id));

        if (planet == null)
            return NotFound();

        return Ok(planet);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPlanetsQuery();
        var planets = await _mediator.Send(query);

        return Ok(planets);
    }

}
