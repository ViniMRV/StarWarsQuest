using StarWarsQuest.Api.DTO.CharactersDTOs;

namespace StarWarsQuest.Api.Models;

public class SwapiPeopleResponse
{
    public List<CharacterDTO> Results { get;set; }
}
