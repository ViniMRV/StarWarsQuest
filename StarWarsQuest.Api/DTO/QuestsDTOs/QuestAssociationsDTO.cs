using StarWarsQuest.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace StarWarsQuest.Api.DTO.QuestsDTOs;

public class QuestAssociationsDTO
{
    [Required]
    public int CharacterId { get; set; }

    [Required]
    public int QuestId { get; set; }

    [Required]
    public int SpaceshipId { get; set; }

}
