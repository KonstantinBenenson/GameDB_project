using GameDB.Data;
using GameDB.Models;

namespace GameDB.Services
{
    public class GameStudioRepository : GenericRepository<GameStudio>, IGameStudioRepository
    {
        public GameStudioRepository(GameDbContext context): base(context)
        {

        }
    }
}
