using StarWarsQuest.Api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace StarWarsQuest.Api.DTO.QuestsDTOs;

public class UpdateQuestDTO
{
    public QuestStatus Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
