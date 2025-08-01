using StarWarsQuest.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace StarWarsQuest.Api.DTO.SpaceshipsDTOs;

public class SpaceshipInfosDTO
{
    public int SpaceshipId { get; set; }
    public string? Name { get; set; }
}
