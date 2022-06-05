using GameDB.Data;
using GameDB.Models;
using GameDB.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GameDB.Services
{
    public class GameStudioRepository : GenericRepository<GameStudio>, IGameStudioRepository
    {
        private readonly GameDbContext _dbContext;
        public GameStudioRepository(GameDbContext context): base(context)
        {
            _dbContext = context;   
        }
    }
}
