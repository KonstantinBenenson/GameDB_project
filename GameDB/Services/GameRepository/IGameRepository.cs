using GameDB.Models;
using GameDB.Models.DTOs;

namespace GameDB.Services
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<IEnumerable<Game>> GetByGenreAsync(string genre);
    }
}