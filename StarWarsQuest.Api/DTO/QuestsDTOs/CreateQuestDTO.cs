using StarWarsQuest.Api.Models;
using StarWarsQuest.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StarWarsQuest.Api.DTO.QuestsDTOs;

public class CreateQuestDTO
{

    [Required(ErrorMessage = "The quest name is Required")]
    [MinLength(15)]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The quest description is Required")]
    [MinLength(15)]
    [MaxLength(200)]
    public string Description { get; set; }
}
