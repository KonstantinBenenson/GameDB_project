using GameDB.Models;
using GameDB.Models.DTOs;

namespace GameDB.Services
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<IList<Game>> GetByGenreAsync(string genre);
        Task<IList<Game>> GetByStudioAsync(string studio);        
    }
}