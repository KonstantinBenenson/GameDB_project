using AutoMapper;
using GameDB.Models;
using GameDB.Models.DTOs;

namespace GameDB.Configurations
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Genre, CreateGenreDTO>().ReverseMap();
            CreateMap<Genre, GetGenreDTO>().ReverseMap();
            CreateMap<Game, CreateGameDTO>().ReverseMap();
            CreateMap<Game, GetGameDTO>().ReverseMap();
            CreateMap<GameStudio, CreateGameStudioDTO>().ReverseMap();
            CreateMap<GameStudio, GetGameStudioDTO>().ReverseMap();
        }
    }
}
