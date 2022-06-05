using GameDB.Models;
using GameDB.Models.DTOs;

namespace GameDB.Services
{
    public interface IGenreGameRepository : IGenericRepository<Genre_Game>
    {
        Task AddRelationWithGenreAsync(CreateGameDTO gameDTO, Game game);
        Task UpdateRelationWithGenreAsync(Game game, CreateGameDTO gameDTO);
    }    
}
