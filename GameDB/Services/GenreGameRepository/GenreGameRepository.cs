using GameDB.Data;
using GameDB.Models;
using GameDB.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GameDB.Services
{
    public class GenreGameRepository : GenericRepository<Genre_Game>, IGenreGameRepository
    {
        private readonly GameDbContext _dbContext;
        public GenreGameRepository(GameDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRelationWithGenreAsync(CreateGameDTO gameDTO, Game game)
        {
            foreach (var item in gameDTO.GenresId)
            {
                var _genre_game = new Genre_Game()
                {
                    GenreId = item,
                    GameId = game.Id
                };
                await _dbContext.AddAsync(_genre_game);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
