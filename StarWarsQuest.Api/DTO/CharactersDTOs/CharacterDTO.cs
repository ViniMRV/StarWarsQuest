using StarWarsQuest.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace StarWarsQuest.Api.DTO.CharactersDTOs;

public class CharacterDTO
{
    [Required(ErrorMessage = "The character name is Required")]
    [MinLength(2)]
    [MaxLength(20)]
    public string? Name { get; set; }

}
