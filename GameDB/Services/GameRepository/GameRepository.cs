using GameDB.Models;
using GameDB.Data;
using Microsoft.EntityFrameworkCore;
using GameDB.Models.DTOs;

namespace GameDB.Services
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly GameDbContext _dbContext;

        public GameRepository(GameDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Game>> GetByGenreAsync(string genre)
        {
            var games = await _dbContext.Games
                .Where(x => x.Genre_Games
                .Any(g => g.Genre.Name == genre)).ToListAsync();
            return games;
        }
    }
}
