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

        private async Task CreateRelationAsync(int id, Game game)
        {
            var _genre_game = new Genre_Game()
            {
                GenreId = id,
                GameId = game.Id
            };
            await _dbContext.AddAsync(_genre_game);
        }
        public async Task AddRelationWithGenreAsync(CreateGameDTO gameDTO, Game game)
        {
            foreach (var item in gameDTO.GenresId)
            {
                await CreateRelationAsync(item, game);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRelationWithGenreAsync(Game game, CreateGameDTO gameDTO)
        {
            var ggList = await _dbContext.Genres_Games.Where(x => x.GameId == game.Id).ToListAsync();

            int maxCapacity = 0;
            if (ggList.Count > gameDTO.GenresId.Count())
                maxCapacity = ggList.Count;
            else
                maxCapacity = gameDTO.GenresId.Count();
            
            for (int i = 0; i <= maxCapacity-1; i++)
            {
                if(i <= gameDTO.GenresId.Count()-1)
                {
                    var obj = await _dbContext.Genres_Games.FirstOrDefaultAsync(gg => gg.Id == ggList[i].Id);
                    obj.GenreId = gameDTO.GenresId[i];                        
                    _dbContext.Update(obj);
                }
                else if(i >= gameDTO.GenresId.Count-1) //Checks if a number of newly added genresId is less that a number of Ids already being stored in the DB.
                {
                    var obj = await _dbContext.Genres_Games.FirstOrDefaultAsync(gg => gg.Id == ggList[i].Id);
                    _dbContext.Remove(obj); 
                }
                else 
                {
                    await CreateRelationAsync(gameDTO.GenresId[i], game);
                } 
            }            
            await _dbContext.SaveChangesAsync();
        }
    }
}
