using AutoMapper;
using StarWarsQuest.Api.DTO.CharactersDTOs;
using StarWarsQuest.Api.DTO.PlanetsDTOs;
using StarWarsQuest.Api.DTO.QuestsDTOs;
using StarWarsQuest.Api.DTO.SpaceshipsDTOs;
using StarWarsQuest.Api.Models;

namespace StarWarsQuest.Api.DTO.Mappings;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterDTO>().ReverseMap();
        CreateMap<Character, CharacterInfosDTO>().ReverseMap();
        CreateMap<Quest, CreateQuestDTO>().ReverseMap();
        CreateMap<Quest, UpdateQuestDTO>().ReverseMap();
        CreateMap<Quest, QuestInfosDTO>().ReverseMap();
        CreateMap<Spaceship, SpaceshipDTO>().ReverseMap();
        CreateMap<Spaceship, SpaceshipInfosDTO>().ReverseMap();
        CreateMap<QuestAssociations, QuestAssociationsDTO>().ReverseMap();
        CreateMap<Planet,PlanetDTO>().ReverseMap();
    }
    
}
